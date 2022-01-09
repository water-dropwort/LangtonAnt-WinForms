using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LangtonAnt_WinForms.Model;
using LangtonAnt_WinForms.Common;

namespace LangtonAnt_WinForms
{
    public partial class Form1 : Form
    {
        #region private fields
        private readonly BackgroundWorker mCellUpdateWorker;
        private readonly System.Threading.SynchronizationContext mMainContext;
        private readonly Bitmap mCellsBmp;
        private readonly Bitmap mColorPaletteBmp;
        private readonly int MAX_CELLS_WIDTH;
        private readonly int MAX_CELLS_HEIGHT;

        private const int NUMBER_OF_ONCE = 10;

        private LangtonAnt mLangtonAnt;
        private int mStep;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Initialize backgroundworker
            mCellUpdateWorker = new BackgroundWorker();
            mCellUpdateWorker.WorkerSupportsCancellation = true;
            mCellUpdateWorker.DoWork += CellUpdateWorker_DoWork;
            mCellUpdateWorker.RunWorkerCompleted += CellUpdateWorker_RunWorkerCompleted;

            // Initialize bitmap
            mCellsBmp = new Bitmap(pctboxCells.Width, pctboxCells.Height);
            pctboxCells.Image = mCellsBmp;
            using (var g = Graphics.FromImage(mCellsBmp))
            {
                g.Clear(this.BackColor);
                pctboxCells.Refresh();
            }

            mColorPaletteBmp = new Bitmap(pctboxColorPalette.Width, pctboxColorPalette.Height);
            pctboxColorPalette.Image = mColorPaletteBmp;
            using (var g = Graphics.FromImage(mColorPaletteBmp))
            {
                g.Clear(this.BackColor);
                pctboxColorPalette.Refresh();
            }

            // Set maximum size.
            MAX_CELLS_WIDTH = mCellsBmp.Width / Consts.CELL_PIXEL_SIZE;
            MAX_CELLS_HEIGHT = mCellsBmp.Height / Consts.CELL_PIXEL_SIZE;

            // Initialize datagridview comobobox
            this.initDirection.Items.Clear();
            this.initDirection.Items.AddRange(Consts.DIRECTION_DICT.Select(pair => pair.Key).ToArray());

            // Subscribe button click events
            btnStart.Click += StartButtonClicked;
            btnStop.Click += StopButtonClicked;
            btnAddAntParam.Click += AddAntParamButtonCliecked;
            btnDeleteAntParam.Click += DeleteAntParamButtonClicked;

            // Set syncronization context
            mMainContext = System.Threading.SynchronizationContext.Current;

            // Set step
            ResetStep();

            // Set default parameter
            txbCellsWidth.Text = Math.Min(100, MAX_CELLS_WIDTH / 2).ToString();
            txbCellsHeight.Text = Math.Min(100, MAX_CELLS_HEIGHT / 2).ToString();
            txbRule.Text = "RL";
            AddAntParameter();

            // Enability
            SetParameterInteractivity(true);
            SetStartStopButtonInteractivity(true);
        }


        #region BackgroundWorker Event Handler
        /// <summary>
        /// Update and drawing cells.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var caller = sender as BackgroundWorker;

            while(true)
            {
                if (caller.CancellationPending)
                    return;

                var updated = new List<Vector<int>>();
                for (int i = 0; i < NUMBER_OF_ONCE; ++i)
                    updated.AddRange(mLangtonAnt.Update());

                mMainContext.Post(_ =>
                {
                    using (var g = Graphics.FromImage(mCellsBmp))
                    {
                        foreach (var i in updated.Distinct())
                        {
                            int x = i.E2 * Consts.CELL_PIXEL_SIZE;
                            int y = i.E1 * Consts.CELL_PIXEL_SIZE;
                            DrawCell(g, x, y, Consts.CELL_COLOR_BRUSHES[mLangtonAnt.Cells[i]]);
                        }
                    }
                    pctboxCells.Refresh();

                    IncrementStep();

                }, null);

                System.Threading.Thread.Sleep(10);
            }
        }

        private void CellUpdateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Enable
            SetParameterInteractivity(true);
            SetStartStopButtonInteractivity(true);
        }
        #endregion

        #region Button Click Event Handler
        /// <summary>
        /// Ant's parameter Add button clicked
        /// </summary>
        private void AddAntParamButtonCliecked(object sender, EventArgs e) => AddAntParameter();

        /// <summary>
        /// Ant's parameter Delete button clicked
        /// </summary>
        private void DeleteAntParamButtonClicked(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dgrdAntParameter.SelectedRows)
                dgrdAntParameter.Rows.Remove(r);
        }

        /// <summary>
        /// Start button clicked
        /// </summary>
        private void StartButtonClicked(object sender, EventArgs e)
        {
            if (mCellUpdateWorker.IsBusy)
                return;

            // Parameter
            var paramres = CreateParameter();
            if(paramres.IsErr) { MessageBox.Show(paramres.ToErr().Value); return; }

            var parameter = paramres.ToOK().Value;

            // Create Langton Ant class
            mLangtonAnt = new LangtonAnt(parameter);

            // Draw color palette
            DrawColorPalette(txbRule.Text);

            // Initialize cells
            using(var g = Graphics.FromImage(mCellsBmp))
            {
                g.Clear(this.BackColor);

                // Draw cells
                for(int i = 0; i < parameter.Rows; ++i)
                {
                    for(int j = 0; j < parameter.Columns; ++j)
                    {
                        int x = j * Consts.CELL_PIXEL_SIZE;
                        int y = i * Consts.CELL_PIXEL_SIZE;
                        DrawCell(g, x, y, Consts.CELL_COLOR_BRUSHES[mLangtonAnt.Cells[i,j]]);
                    }
                }

                pctboxCells.Refresh();
            }

            ResetStep();

            SetParameterInteractivity(false);
            SetStartStopButtonInteractivity(false);

            mCellUpdateWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Stop button clicked
        /// </summary>
        private void StopButtonClicked(object sender, EventArgs e) => mCellUpdateWorker.CancelAsync();
        #endregion

        #region Drawing functions
        /// <summary>
        /// Draw cell
        /// </summary>
        private void DrawCell(Graphics g, int x, int y, SolidBrush br) => g.FillRectangle(br, x, y, Consts.CELL_PIXEL_SIZE, Consts.CELL_PIXEL_SIZE);

        /// <summary>
        /// Draw color palette of rule
        /// </summary>
        private void DrawColorPalette(string rulestr)
        {
            using (var g = Graphics.FromImage(mColorPaletteBmp))
            {
                g.Clear(this.BackColor);

                int blank = 4;
                int cellsize = Math.Min(
                    mColorPaletteBmp.Width / 2 - blank,
                    (pctboxColorPalette.Height - blank * (Consts.CELL_COLORS.Count + 1)) / Consts.CELL_COLORS.Count);

                for (int i = 0; i < rulestr.Length; ++i)
                {
                    int y = (i + 1) * blank + i * cellsize;
                    g.FillRectangle(Consts.CELL_COLOR_BRUSHES[i], 0, y, cellsize, cellsize);
                    g.DrawString(new string(rulestr[i], 1), this.Font, new SolidBrush(this.ForeColor), blank + cellsize, y);
                }

                pctboxColorPalette.Refresh();
            }
        }
        #endregion

        #region Parameter functions
        /// <summary>
        /// Add ant parameter to data grid view.
        /// </summary>
        private void AddAntParameter() => dgrdAntParameter.Rows.Add(new object[] { "", "", Consts.DIRECTION_DICT.Keys.First() });

        /// <summary>
        /// Create parameter
        /// </summary>
        private Result<Parameter, string> CreateParameter()
        {
            // rule
            var ruleres = ParseRule(txbRule.Text);
            if (ruleres.IsErr)
                return new Result<Parameter, string>.Err(ruleres.ToErr().Value);

            // ant parameter
            var antsres = CreateAntParameters();
            if (antsres.IsErr)
                return new Result<Parameter, string>.Err(antsres.ToErr().Value);

            // Widht
            var widthres = FormHelper.TryParseToInt(txbCellsWidth.Text, "Width").AndThen(InRangeW);
            if (widthres.IsErr)
                return new Result<Parameter, string>.Err(widthres.ToErr().Value);

            // Height
            var heightres = FormHelper.TryParseToInt(txbCellsHeight.Text, "Height").AndThen(InRangeH);
            if (heightres.IsErr)
                return new Result<Parameter, string>.Err(heightres.ToErr().Value);

            return new Result<Parameter, string>.OK(new Parameter(
                ruleres.ToOK().Value, 
                antsres.ToOK().Value,
                heightres.ToOK().Value,
                widthres.ToOK().Value));
        }

        private Result<int, string> InRangeW(int v) => FormHelper.InRange(v, 1, MAX_CELLS_WIDTH, "Width");
        private Result<int, string> InRangeH(int v) => FormHelper.InRange(v, 1, MAX_CELLS_HEIGHT, "Height");

        /// <summary>
        /// Parse rule string to array of Behavior.
        /// </summary>
        private Result<Behavior[], string> ParseRule(string rulestr)
        {
            if (rulestr.Length < 2 || Consts.CELL_COLOR_BRUSHES.Count < rulestr.Length)
                return new Result<Behavior[], string>.Err($"Length of Rule is not between 2 to {Consts.CELL_COLOR_BRUSHES.Count}.");

            var list = new List<Behavior>();
            foreach (var c in rulestr)
            {
                if (Consts.BEHAVIOR_CHARS.TryGetValue(c, out Behavior beh))
                    list.Add(beh);
                else
                    return new Result<Behavior[], string>.Err($"Rule contains invalid character:{c}.");
            }
            return new Result<Behavior[], string>.OK(list.ToArray());
        }

        /// <summary>
        /// Create ant parameters
        /// </summary>
        private Result<AntParameter[], string> CreateAntParameters()
        {
            var list = new List<AntParameter>();
            string format = "Failed to parse : Row={0},Column={1}";

            if (dgrdAntParameter.Rows.Count == 0)
                return new Result<AntParameter[], string>.Err("Please add one or more ant parameter.");
            
            try
            {
                foreach(DataGridViewRow r in dgrdAntParameter.Rows)
                {
                    // X postion 
                    if (false == FormHelper.TryParseToNullableInt((string)r.Cells[0].Value, out int? x))
                        return new Result<AntParameter[], string>.Err(string.Format(format, r.Index, 0));
                    // Y position
                    if (false == FormHelper.TryParseToNullableInt((string)r.Cells[1].Value, out int? y))
                        return new Result<AntParameter[], string>.Err(string.Format(format, r.Index, 1));
                    // Direction
                    if(false == Consts.DIRECTION_DICT.TryGetValue((string)r.Cells[2].Value, out Direction? direction))
                        return new Result<AntParameter[], string>.Err(string.Format("Undefined value : Row{0},Column={1}", r.Index, 2));

                    list.Add(new AntParameter(y, x, direction));
                }

                return new Result<AntParameter[], string>.OK(list.ToArray());
            }
            catch(Exception ex)
            {
                return new Result<AntParameter[], string>.Err(ex.Message);
            }
        }
        #endregion

        #region set enabled property functions
        /// <summary>
        /// Set enable or disable to parameter's controls.
        /// </summary>
        private void SetParameterInteractivity(bool isEnabled)
        {
            txbCellsHeight.Enabled = isEnabled;
            txbCellsWidth.Enabled = isEnabled;
            txbRule.Enabled = isEnabled;
            btnAddAntParam.Enabled = isEnabled;
            btnDeleteAntParam.Enabled = isEnabled;
            dgrdAntParameter.Enabled = isEnabled;
        }

        /// <summary>
        /// Set enable or disable to start/stop button.
        /// If start button is enable(disable), stop button is disable(enable).
        /// </summary>
        private void SetStartStopButtonInteractivity(bool isStartButtonEnable)
        {
            btnStart.Enabled = isStartButtonEnable;
            btnStop.Enabled = !isStartButtonEnable; // reverse
        }
        #endregion

        #region step function
        /// <summary>
        /// 0-Clear step number
        /// </summary>
        private void ResetStep()
        {
            mStep = 0;
            lblStepValue.Text = mStep.ToString();
        }

        /// <summary>
        /// Increment step number
        /// </summary>
        private void IncrementStep()
        {
            mStep += NUMBER_OF_ONCE;
            lblStepValue.Text = mStep.ToString();
        }
        #endregion
    }
}
