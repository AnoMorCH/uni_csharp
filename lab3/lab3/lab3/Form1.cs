using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();

        // Setting up the parameters.
        private static int standardSize = 10;
        public int curveWidth = standardSize;
        public int pointRadius = standardSize;

        // Painting.
        private bool isSettingOfPointsPermitted = false;
        private bool areCurvesPainted = false;
        private bool areBrokenLinesPainted = false;
        private bool areBezierLinesPainted = false;
        private bool isFillCurvePainted = false;
        private int amountOfPointsToDrawBezier = 4;

        // Saved painting.
        private bool areCurvesSaved = false;
        private bool areBrokenLinesSaved = false;
        private bool areBezierLinesSaved = false;
        private bool isFillCurveSaved = false;

        // Moving.
        private Timer moveTimer = new Timer();
        private int tick = 50;
        private bool isMovingEnabled = false;
        private (int, int)[] directions;
        private int leftWindowBorder;
        private int rightWindowBorder;
        private int upWindowBorder;
        private int downWindowBorder;

        // Additional speed on keys.
        private int stepToMove;
        private int speedOX = 0;
        private int speedOY = 0;

        // Dragging.
        private int draggingPointId;
        private bool isDraggingEnabled = false;

        // Saving (there is only one set of points you can preserve).
        private List<Point> savedPoints;

        public Form1()
        {
            InitializeComponent();

            Width = 600;
            Height = 600;

            // Manage moving.
            stepToMove = pointRadius / 2;
            moveTimer.Interval = 500;
            moveTimer.Tick += TimerTickHandler;

            // Manage clicks on buttons.
            PointsButton.Click += ChangePointsShowStatusOnClick;
            ParametersButton.Click += ShowParametersFormOnClick;
            CurveButton.Click += DrawCurveOnClick;
            BrokenLineButton.Click += DrawBrokenLinesOnClick;
            BezierButton.Click += DrawBeziersOnClick;
            FillCurveButton.Click += DrawFillCurveOnClick;
            MovingButton.Click += StartTimerOnClick;
            MovingButton.Click += EnableMovingOnClick;
            CleanButton.Click += CleanFormOnClick;
            SaveButton.Click += SaveFigure;

            // Manage clicks on keys.
            KeyPreview = true;
            KeyDown += EnableMovingOnSpaceKeyClick;
            KeyDown += SpeedUpOnPlusKeyClick;
            KeyDown += SpeedDownOnMinusKeyClick;
            KeyDown += CleanFormOnEscapeKeyClick;

            // Manage moving of a point.
            MouseDown += MouseOnDown;
            MouseMove += MouseOnMove;
            MouseUp += MouseOnUp;

            // Set size of borders to move a figure.
            leftWindowBorder = 0;
            rightWindowBorder = Width;
            downWindowBorder = 0;
            upWindowBorder = Height;

            // Set up points on the form.
            MouseClick += MouseOnClick;

            Paint += PaintHandler;
        }

        private bool CorrectAmountOfPointsToDrawBezier()
        {
            return points.Count == amountOfPointsToDrawBezier;
        }

        private void MovePoints()
        {
            var tempPoints = new List<Point>();

            for (int i = 0; i < points.Count; i++)
            {
                var dx = directions[i].Item1;
                var dy = directions[i].Item2;
                Point point = new Point(points[i].X + dx, points[i].Y + dy);

                if (point.X - pointRadius <= leftWindowBorder || point.X + pointRadius >= rightWindowBorder)
                {
                    directions[i] = (-dx, dy);
                    point.X -= dx;
                    point.Y -= dy;
                }

                if (point.Y - pointRadius >= upWindowBorder || point.Y + pointRadius <= downWindowBorder)
                {
                    directions[i] = (dx, -dy);
                    point.X -= dx;
                    point.Y -= dy;
                }

                tempPoints.Add(point);
            }

            points = tempPoints;

            if (!isMovingEnabled)
            {
                moveTimer.Stop();
            }
        }

        private void ChangePointsShowStatusOnClick(object sender, EventArgs e)
        {
            isSettingOfPointsPermitted = !isSettingOfPointsPermitted;
        }

        private void ShowParametersFormOnClick(object sender, EventArgs e)
        {
            ParamForm paramForm = new ParamForm(this);
            paramForm.ShowDialog();
        }

        private void DrawCurveOnClick(object sender, EventArgs e)
        {
            areCurvesPainted = !areCurvesPainted;
            Refresh();
        }

        private void DrawBrokenLinesOnClick(object sender, EventArgs e)
        {
            areBrokenLinesPainted = !areBrokenLinesPainted;
            Refresh();
        }

        private void DrawBeziersOnClick(object sender, EventArgs e)
        {
            areBezierLinesPainted = !areBezierLinesPainted;
            Refresh();
        }

        private void DrawFillCurveOnClick(object sender, EventArgs e)
        {
            isFillCurvePainted = !isFillCurvePainted;
            Refresh();
        }

        private void EnableMovingOnClick(object sender, EventArgs e)
        {
            isMovingEnabled = !isMovingEnabled;

            Random random = new Random();
            var randomDirections = new[] { -pointRadius, 0, pointRadius };
            directions = new (int, int)[points.Count];

            for (int i = 0; i < directions.Length; i++)
            {
                while (directions[i].Item1 == 0 && directions[i].Item2 == 0)
                {
                    directions[i] = (
                        randomDirections[random.Next(0, randomDirections.Length)],
                        randomDirections[random.Next(0, randomDirections.Length)]
                    );
                }
            }

            moveTimer.Start();
        }

        private void StartTimerOnClick(object sender, EventArgs e)
        {
            moveTimer.Start();
        }

        private void CleanFormOnClick(object sender, EventArgs e)
        {
            isSettingOfPointsPermitted = false;
            areCurvesPainted = false;
            areBrokenLinesPainted = false;
            areBezierLinesPainted = false;
            isFillCurvePainted = false;
            isMovingEnabled = false;
            points.Clear();
            Refresh();
        }

        private void EnableMovingOnSpaceKeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                EnableMovingOnClick(sender, e);
                Refresh();
                e.Handled = true;
            }
        }

        private void SpeedUpOnPlusKeyClick(object sender, KeyEventArgs e)
        {
            bool canMovingBeFaster()
            {
                return moveTimer.Interval - tick > 0;
            }

            if (e.KeyCode == Keys.Add && canMovingBeFaster())
            {
                moveTimer.Interval -= tick;
                Refresh();
                e.Handled = true;
            }
        }

        private void SpeedDownOnMinusKeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract)
            {
                moveTimer.Interval += tick;
                Refresh();
                e.Handled = true;
            }
        }

        private void CleanFormOnEscapeKeyClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                CleanFormOnClick(sender, e);
                e.Handled = true;
            }
        }

        private void MouseOnClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isSettingOfPointsPermitted)
            {
                Point point = e.Location;
                points.Add(point);
                Refresh();
            }
        }

        private void SaveFigure(object sender, EventArgs e)
        {
            areCurvesSaved = areCurvesPainted;
            areBrokenLinesSaved = areBrokenLinesPainted;
            areBezierLinesSaved = areBrokenLinesPainted;
            isFillCurveSaved = isFillCurvePainted;
            savedPoints = new List<Point>(points);
            CleanFormOnClick(sender, e);
            Refresh();
        }

        private void TimerTickHandler(object sender, EventArgs e)
        {
            MovePoints();
            Refresh();
        }

        public void PaintHandler(object sender, PaintEventArgs e)
        {
            Pen standardDrawPan = new Pen(Color.Pink, curveWidth);
            SolidBrush standardDrawBrush = new SolidBrush(Color.Pink);

            Pen savedDrawPan = new Pen(Color.Gray, curveWidth);
            SolidBrush savedDrawBrush = new SolidBrush(Color.Gray);

            if (isSettingOfPointsPermitted)
            {
                foreach (Point point in points)
                {
                    e.Graphics.DrawEllipse(Pens.Blue, point.X, point.Y, pointRadius, pointRadius);
                    e.Graphics.FillEllipse(Brushes.Blue, point.X, point.Y, pointRadius, pointRadius);
                }
                Refresh();
            }

            if (areCurvesPainted)
            {
                e.Graphics.DrawClosedCurve(standardDrawPan, points.ToArray());
            }

            if (areCurvesSaved)
            {
                e.Graphics.DrawClosedCurve(savedDrawPan, savedPoints.ToArray());
            }

            if (areBrokenLinesPainted)
            {
                e.Graphics.DrawPolygon(standardDrawPan, points.ToArray());
            }

            if (areBrokenLinesSaved)
            {
                e.Graphics.DrawPolygon(savedDrawPan, savedPoints.ToArray());
            }

            if (areBezierLinesPainted && CorrectAmountOfPointsToDrawBezier())
            {
                e.Graphics.DrawBezier(
                    standardDrawPan, 
                    points[0], 
                    points[1],
                    points[2], 
                    points[3]
                );
            }

            if (areBezierLinesSaved && CorrectAmountOfPointsToDrawBezier())
            {
                e.Graphics.DrawBezier(
                    savedDrawPan,
                    savedPoints[0],
                    savedPoints[1],
                    savedPoints[2],
                    savedPoints[3]
                );
            }

            if (isFillCurvePainted)
            {
                e.Graphics.FillClosedCurve(standardDrawBrush, points.ToArray());
            }

            if (isFillCurveSaved)
            {
                e.Graphics.FillClosedCurve(savedDrawBrush, savedPoints.ToArray());
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (isMovingEnabled)
            {
                List<Keys> movingKeys = new List<Keys>()
                {
                    Keys.Up,
                    Keys.Down,
                    Keys.Left,
                    Keys.Right
                };

                if (keyData == Keys.Up)
                {
                    speedOY += stepToMove;
                }
                else if (keyData == Keys.Down && speedOY > 0)
                {
                    speedOY -= stepToMove;
                }
                else if (keyData == Keys.Left && speedOX > 0)
                {
                    speedOX -= stepToMove;
                }
                else if (keyData == Keys.Right)
                {
                    speedOX += stepToMove;
                }

                for (int i = 0; i < directions.Length; i++)
                {
                    if (directions[i].Item1 < 0) 
                    {
                        speedOX = -speedOX;
                    }

                    if (directions[i].Item2 < 0)
                    {
                        speedOY = -speedOY;
                    }


                    directions[i] = (
                        directions[i].Item1 + speedOX,
                        directions[i].Item2 + speedOY
                    );
                }

                if (movingKeys.Contains(keyData))
                {
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MouseOnDown(object sender, MouseEventArgs e) 
        {
            int acceptableRange = 2 * pointRadius;

            bool IsOnPoint(Point location, Point point)
            {
                bool isOXAcceptable = location.X - point.X < acceptableRange;
                bool isOYAcceptable = location.Y - point.Y < acceptableRange;
                return isOXAcceptable && isOYAcceptable;
            }

            for (int pointId = 0; pointId < points.Count; pointId++) 
            {
                Point point = points[pointId];

                if (IsOnPoint(e.Location, point))
                {
                    draggingPointId = pointId;
                    isDraggingEnabled = true;
                }
            }
        }

        private void MouseOnMove(object sender, MouseEventArgs e)
        {
            if (isDraggingEnabled)
            {
                points[draggingPointId] = new Point(e.Location.X, e.Location.Y);
                Refresh();
            }
        }

        private void MouseOnUp(object sender, MouseEventArgs e)
        {
            isDraggingEnabled = false;
        }
    }
}
