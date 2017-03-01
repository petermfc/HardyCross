using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardy
{
    public class PipeModel
    {
        private static readonly int NODE_RADIUS = 4;
        private static readonly int PIPE_THICKNESS = 2;
        private static readonly int IN_OUT_THICKNESS = 1;
        private static readonly int LOCK_RADIUS = 10;
        private static readonly int INOUTS_OFFSET = 20;
        private static readonly int INOUTS_LENGTH = 35;
        private static readonly int LOSS_LENGTH = 60;
        private static int PIPE_LENGTH = 40;
        private Brush nodeBrush, edgeBrush, lockedEdgeBrush, inOutsBrush, lossBrush;
        private Pen lockPen, pipePen, lockedPipePen, inOutPen, inOutPenLocked, lossPen;
        StringFormat stringFormat;
        Font drawFont, boldDrawFont, normalFont, lossFont;
        Rectangle lockedArea;
        Vertex<Node> lockedVertex;
        Vertex<Node> selectedVertex;
        Edge<Node> lockedEdge;

        private bool addPipeInProgress;

        private Graph<Node> network;
        public Graph<Node> Network
        {
            get
            {
                return network;
            }
            set
            {
                network = value;
                lockedArea = new Rectangle();
                lockedEdge = null;
                lockedVertex = null;
                selectedVertex = null;
            }
        }
        public void DoShit()
        {
            int[][] data = network.AsListOfEdges();
            akCyclesInUndirectedGraphs.CyclesHelper.SetGraph(data);
            List<string> ret = akCyclesInUndirectedGraphs.CyclesHelper.demo();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < ret.Count(); i++)
            {
                string line = "Cycle " + (i + 1) + ": " + ret[i];
                sb.AppendLine(line);
            }
            MessageBox.Show(sb.ToString());
        }

        public PipeModel()
        {
            this.nodeBrush = new SolidBrush(Color.Red);
            this.edgeBrush = new SolidBrush(Color.Black);
            this.lockedEdgeBrush = new SolidBrush(Color.GreenYellow);
            this.inOutsBrush = new SolidBrush(Color.Black);
            this.lossBrush = new SolidBrush(Color.ForestGreen);
            pipePen = new Pen(Color.Black, PIPE_THICKNESS);
            lockPen = new Pen(Color.Blue);
            lockedPipePen = new Pen(Color.GreenYellow, PIPE_THICKNESS);
            inOutPen = new Pen(Color.Black, IN_OUT_THICKNESS);
            inOutPenLocked = new Pen(Color.GreenYellow, IN_OUT_THICKNESS);
            lossPen = new Pen(Color.ForestGreen);
            stringFormat = new StringFormat();
            drawFont = new Font("Arial", 12);
            boldDrawFont = new Font("Arial", 12, FontStyle.Bold);
            normalFont = new Font("Arial", 10);
            lossFont = new Font("Arial", 8);
            this.network = new Graph<Node>();
            lockedArea = Rectangle.Empty;
            lockedVertex = null;
            lockedEdge = new Edge<Node>() { Value = false, Length = 0 };
            selectedVertex = null;
            addPipeInProgress = false;
        }

        public bool AddNode(MouseEventArgs args)
        {
            addPipeInProgress = false;
            Node n = new Node(args.Location);
            Vertex<Node> v = new Vertex<Node>();
            v.Data = n;
            network.Add(v);
            return true;
        }

        public bool DeleteNode(MouseEventArgs args)
        {
            bool bRet = false;
            addPipeInProgress = false;
            if (lockedArea.Contains(args.Location))
            {
                network.Remove(lockedVertex);
                lockedVertex = null;
                bRet = true;
            }
            return bRet;
        }

        public bool AddPipe(MouseEventArgs args)
        {
            bool bRet = false;
            if (!addPipeInProgress)
            {
                if (lockedArea.Contains(args.Location))
                {
                    addPipeInProgress = true;
                    selectedVertex = lockedVertex;
                }
            }
            else
            {
                if (lockedArea.Contains(args.Location))
                {
                    if (lockedVertex == null || selectedVertex == null || selectedVertex == lockedVertex)
                        return false;
                    addPipeInProgress = false;
                    network.AddEdge(selectedVertex, lockedVertex);

                    //Vertex<Node> bigger = selectedVertex.Index > lockedVertex.Index ? selectedVertex : lockedVertex;
                    //Vertex<Node> lower = selectedVertex.Index < lockedVertex.Index ? selectedVertex : lockedVertex;
                    //RebuildInOuts(bigger);
                    //RebuildInOuts(lower);

                    selectedVertex = null;
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool DeletePipe(MouseEventArgs args)
        {
            bool bRet = false;
            addPipeInProgress = false;
            if (lockedArea.Contains(args.Location))
            {
                if (lockedEdge == null)
                    return false;
                addPipeInProgress = false;
                network.RemoveEdge(lockedEdge.Beginning, lockedEdge.End);

                //Vertex<Node> bigger = selectedVertex.Index > lockedVertex.Index ? selectedVertex : lockedVertex;
                //Vertex<Node> lower = selectedVertex.Index < lockedVertex.Index ? selectedVertex : lockedVertex;
                //RebuildInOuts(bigger);
                //RebuildInOuts(lower);

                selectedVertex = null;
                bRet = true;
            }
            return bRet;
        }
    

        public Tuple<Rectangle, Rectangle> TryLockTarget(MouseEventArgs args)
        {
            foreach(var v in network.Vertices)  //vertices
            {
                Rectangle r = new Rectangle(v.Data.Position.X - LOCK_RADIUS -1, v.Data.Position.Y -1 - LOCK_RADIUS, LOCK_RADIUS * 2 +2, LOCK_RADIUS * 2+2);
                //if(n.Position.X >= (args.X - LOCK_RADIUS) && n.Position.X <= (args.X + LOCK_RADIUS)
                //    && n.Position.Y >= (args.Y - LOCK_RADIUS) && n.Position.Y <= (args.Y + LOCK_RADIUS))
                if(r.Contains(args.Location))
                {
                    if(lockedVertex != null)
                        lockedVertex.Data.IsLocked = false;
                    v.Data.IsLocked = true;
                    Tuple<Rectangle, Rectangle> ret = new Tuple<Rectangle, Rectangle>(r, lockedArea); //return prev and current locked area (to invalidate properly)
                    lockedArea = r;
                    lockedVertex = v;
                    return ret;
                }
            }

            for (int i = 0; i < network.Edges.Count; i++) //do not process last column
            {
                for (int j = 0; j < network.Edges[i].Count; j++)
                {
                    Edge<Node> e = network.Edges[i][j];
                    if(e.Value)
                    {
                        Point p1 = network.Vertices[i].Data.Position;
                        Point p2 = network.Vertices[j].Data.Position;
                        Rectangle r = new Rectangle(args.Location.X - LOCK_RADIUS - 1, args.Location.Y - 1 - LOCK_RADIUS, LOCK_RADIUS * 2 + 2, LOCK_RADIUS * 2 + 2);
                        if (LineIntersectsRect(p1, p2, r))
                        {
                            if (lockedEdge != null)
                                lockedEdge.IsLocked = false;
                            Rectangle vertexRect = ResetVertexLock();
                            e.IsLocked = true;
                            lockedEdge = e;
                            Tuple<Rectangle, Rectangle> ret = new Tuple<Rectangle, Rectangle>(r, vertexRect);
                            lockedArea = r;
                            return ret;
                        }
                    }
                }
            }
            Rectangle re = Rectangle.Empty;
            if (lockedVertex != null)
            {
                lockedVertex.Data.IsLocked = false;
                lockedVertex = null;
                re = lockedArea;
                lockedArea = Rectangle.Empty;
            }
            if (lockedEdge != null)
            {
                lockedEdge.IsLocked = false;
                lockedEdge = null;
                re = lockedArea;
                lockedArea = Rectangle.Empty;
            }
            return new Tuple<Rectangle, Rectangle>(Rectangle.Empty, re);
        }
        
        public bool ShowProps(MouseEventArgs args)
        {
            bool redraw = false;
            PropertiesDialog pd = null;
            if (lockedVertex != null)
            {
                pd = new PropertiesDialog(lockedVertex.Data.NodeLoss, lockedVertex.Data.Type, lockedVertex.Data.IsStartElement);
                pd.Text = "Node #" + lockedVertex.Index;
                int numOfNeighbors = network.GetAdjacentVerticesTo(lockedVertex).Count();
                var startElement = network.Vertices.Where(v => v.Data.IsStartElement == true).FirstOrDefault();
                if ((startElement == lockedVertex || startElement == null) && numOfNeighbors < 2)
                    pd.StartElementCheckboxLock = false;
                else if((startElement != null && startElement != lockedVertex) || numOfNeighbors > 1)
                    pd.StartElementCheckboxLock = true;
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    lockedVertex.Data.NodeLoss = pd.NodeLoss;
                    lockedVertex.Data.Type = pd.Type;
                    lockedVertex.Data.IsStartElement = pd.IsStartElement;
                    redraw = true;
                }

            }
            else if (lockedEdge != null)
            {
                pd = new PropertiesDialog(lockedEdge.Length, lockedEdge.PipeLoss, lockedEdge.C, lockedEdge.Diameter, lockedEdge.Qstart, lockedEdge.Qend, lockedEdge.Sign, lockedEdge.DrawReversed);
                pd.Text = "Pipe";
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    Edge<Node> mirror = network.Edges[lockedEdge.End.Index - 1][lockedEdge.Beginning.Index - 1];
                    lockedEdge.Length = mirror.Length = pd.Length;
                    lockedEdge.PipeLoss = mirror.PipeLoss = pd.PipeLoss;
                    lockedEdge.C = mirror.C = pd.C;
                    lockedEdge.Diameter = mirror.Diameter = pd.Diameter;
                    lockedEdge.Qstart = mirror.Qstart = pd.Qs;
                    lockedEdge.Qend = mirror.Qend = pd.Qe;
                    lockedEdge.DrawReversed = mirror.DrawReversed = pd.Reversed;
                    lockedEdge.Sign = mirror.Sign = pd.Sign;
                    redraw = true;
                }
            }
            return redraw;
        }

        public void Draw(Graphics g)
        {
            foreach(var v in network.Vertices) //vertices
            {
                Point p = v.Data.Position;
                Point pointFont = new Point(p.X - NODE_RADIUS - 10, p.Y - NODE_RADIUS - 10);
                Rectangle rect = new Rectangle(p.X - NODE_RADIUS, p.Y - NODE_RADIUS, NODE_RADIUS*2, NODE_RADIUS*2);
                g.FillEllipse(nodeBrush, rect);
                string glyph = GetGlyph(v);
                if(!v.Data.IsStartElement)
                    g.DrawString(glyph, drawFont, nodeBrush, pointFont);
                else
                    g.DrawString(glyph, boldDrawFont, nodeBrush, pointFont);
                g.DrawString(glyph, drawFont, nodeBrush, pointFont);

                //drawing nodes loss
                List<Vertex<Node>> adjVertexes = network.GetAdjacentVerticesTo(v);
                if (v.Data.Type == NodeType.Node && adjVertexes.Count() > 1)
                {
                    float maxAngle = 0;
                    Point pBisect = new Point();
                    for (int i = 0; i < adjVertexes.Count(); i++)
                    {
                        Point pf = adjVertexes[i].Data.Position;
                        Point pn;
                        if (i + 1 != adjVertexes.Count())
                            pn = adjVertexes[i + 1].Data.Position;
                        else
                            pn = adjVertexes[0].Data.Position;
                        float angle = MathHelper.P3A(pf, p, pn);
                        if (Math.Abs(angle) > maxAngle)
                            maxAngle = angle;
                    }
                    GraphicsState state = g.Save();
                    g.TranslateTransform(p.X, p.Y);
                    g.RotateTransform(360 - maxAngle);
                    pBisect = new Point(0, LOSS_LENGTH);
                    lossPen.CustomEndCap = new AdjustableArrowCap(2, 4);
                    g.DrawLine(lossPen, new Point(), pBisect);
                    g.TranslateTransform(pBisect.X, pBisect.Y);
                    g.RotateTransform(270);
                    g.DrawString(v.Data.NodeLoss.ToString(), lossFont, lossBrush, new Point());
                    g.Restore(state);
                }

                if (v.Data.IsLocked)
                {
                    Rectangle r = new Rectangle(p.X - LOCK_RADIUS, p.Y - LOCK_RADIUS, LOCK_RADIUS*2, LOCK_RADIUS*2);
                    g.DrawRectangle(lockPen, r);
                }
            }

            for(int i = 0; i < network.Edges.Count; i++)
            {
                List<Edge<Node>> edgesRow = network.Edges[i];
                for (int j = i; j < edgesRow.Count; j++)
                {
                    Edge<Node> e = edgesRow[j];
                    if (e.Value)
                    {
                        Point p1;
                        Point p2;
                        if(!e.DrawReversed)
                        {
                            p1 = network.Vertices[i].Data.Position;
                            p2 = network.Vertices[j].Data.Position;
                        }
                        else
                        {
                            p1 = network.Vertices[j].Data.Position;
                            p2 = network.Vertices[i].Data.Position;
                        }
                        double lenX = p1.X - p2.X;
                        double lenY = p1.Y - p2.Y;
                        double absLenX = Math.Abs(lenX);
                        double absLenY = Math.Abs(lenY);
                        int x = (int)Math.Floor(absLenX / 2 + Math.Min(p1.X, p2.X));
                        int y = (int)Math.Floor(absLenY / 2 + Math.Min(p1.Y, p2.Y));
                        Point middlePoint = new Point(x, y);
                        float angleDegrees = (float)(Math.Atan2(lenY, lenX) * 180 / Math.PI);
                        if (!e.IsLocked)
                        {
                            g.DrawLine(pipePen, p1, p2);
                            DrawHelper.DrawRotatedString(e.Length.ToString(), drawFont, edgeBrush, middlePoint, angleDegrees, 0.0f, drawFont.Size * 0.5, g);
                            DrawHelper.DrawRotatedString(e.PipeLoss.ToString(), drawFont, edgeBrush, middlePoint, angleDegrees, 0.0f, drawFont.Size * -2.5, g);
                            DrawHelper.DrawRotatedArrow(pipePen, middlePoint, PIPE_LENGTH, angleDegrees, 0.0f, drawFont.Size * -0.5, false /*e.CounterClockwise*/, g);
                        }
                        else
                        {
                            g.DrawLine(lockedPipePen, p1, p2);
                            DrawHelper.DrawRotatedString(e.Length.ToString(), drawFont, lockedEdgeBrush, middlePoint, angleDegrees, 0.0f, drawFont.Size * 0.5, g);
                            DrawHelper.DrawRotatedString(e.PipeLoss.ToString(), drawFont, lockedEdgeBrush, middlePoint, angleDegrees, 0.0f, drawFont.Size * -2.5, g);
                            DrawHelper.DrawRotatedArrow(lockedPipePen, middlePoint, PIPE_LENGTH, angleDegrees, 0.0f, drawFont.Size * -0.5, false/*e.CounterClockwise*/, g);
                        }

                        //drawind qs
                        int angleSign = Math.Sign(angleDegrees);
                        GraphicsState state = g.Save();
                        g.TranslateTransform(p1.X, p1.Y);
                        g.RotateTransform(angleDegrees);
                        PointF inOutStart = new PointF(-INOUTS_OFFSET, 0);
                        PointF inOutEnd = new PointF(-INOUTS_OFFSET, INOUTS_LENGTH * angleSign);
                        g.DrawLine(inOutPen, inOutStart, inOutEnd);
                        g.TranslateTransform(inOutStart.X, inOutStart.Y);
                        g.RotateTransform(90 * angleSign);
                        Point pText = new Point(INOUTS_LENGTH, 0);
                        g.TranslateTransform(pText.X, pText.Y);
                        g.RotateTransform(180);
                        pText = new Point(0, 0);
                        g.DrawString(e.Qstart.ToString(), normalFont, inOutsBrush, pText);
                        g.Restore(state);

                        //drawing qe
                        state = g.Save();
                        g.TranslateTransform(p2.X, p2.Y);
                        g.RotateTransform(angleDegrees);
                        inOutStart = new PointF(INOUTS_OFFSET, 0);
                        inOutEnd = new PointF(INOUTS_OFFSET, INOUTS_LENGTH * angleSign);
                        g.DrawLine(inOutPen, inOutStart, inOutEnd);
                        g.TranslateTransform(inOutStart.X, inOutStart.Y);
                        g.RotateTransform(90 * angleSign);
                        pText = new Point(INOUTS_LENGTH, 0);
                        g.TranslateTransform(pText.X, pText.Y);
                        g.RotateTransform(180);
                        pText = new Point(0, 0);
                        g.DrawString(e.Qend.ToString(), normalFont, inOutsBrush, pText);
                        g.Restore(state);
                    }
                }
            }
        }

        private String GetGlyph(Vertex<Node> v)
        {

            string ret = String.Empty;
            switch (v.Data.Type)
            {
                case NodeType.Node:
                    ret = v.Index.ToString();
                        break;
                case NodeType.Unspecified:
                    ret = "U";
                    break;
                case NodeType.Pump:
                    ret = "P";
                    break;
                case NodeType.Container:
                    ret = "Z";
                    break;
                case NodeType.Reservoir:
                    ret = "R";
                    break;
            }
            return ret;
        }

        private Rectangle ResetVertexLock()
        {
            Rectangle re = Rectangle.Empty;
            if (lockedVertex != null)
            {
                lockedVertex.Data.IsLocked = false;
                lockedVertex = null;
                re = lockedArea;
                lockedArea = Rectangle.Empty;
            }
            return re;
        }

        //private void RebuildInOuts(Vertex<Node> vertex)
        //{
        //    Dictionary<int, decimal> inDict = new Dictionary<int, decimal>();
        //    Dictionary<int, decimal> outDict = new Dictionary<int, decimal>();

        //    List<Vertex<Node>> lstAdj = network.GetAdjacentVerticesTo(vertex);
        //    foreach(Vertex<Node> v in lstAdj)
        //    {
        //        if (v.Index < vertex.Index)
        //            inDict[v.Index] = 0;
        //        else
        //            outDict[v.Index] = 0;
        //    }
        //    vertex.Data.In = inDict;
        //    vertex.Data.Out = outDict;
        //}

        public static bool LineIntersectsRect(Point p1, Point p2, Rectangle r)
        {
            return LineIntersectsLine(p1, p2, new Point(r.X, r.Y), new Point(r.X + r.Width, r.Y)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y), new Point(r.X + r.Width, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X + r.Width, r.Y + r.Height), new Point(r.X, r.Y + r.Height)) ||
                   LineIntersectsLine(p1, p2, new Point(r.X, r.Y + r.Height), new Point(r.X, r.Y)) ||
                   (r.Contains(p1) && r.Contains(p2));
        }

        private static bool LineIntersectsLine(Point l1p1, Point l1p2, Point l2p1, Point l2p2)
        {
            float q = (l1p1.Y - l2p1.Y) * (l2p2.X - l2p1.X) - (l1p1.X - l2p1.X) * (l2p2.Y - l2p1.Y);
            float d = (l1p2.X - l1p1.X) * (l2p2.Y - l2p1.Y) - (l1p2.Y - l1p1.Y) * (l2p2.X - l2p1.X);

            if (d == 0)
            {
                return false;
            }

            float r = q / d;

            q = (l1p1.Y - l2p1.Y) * (l1p2.X - l1p1.X) - (l1p1.X - l2p1.X) * (l1p2.Y - l1p1.Y);
            float s = q / d;

            if (r < 0 || r > 1 || s < 0 || s > 1)
            {
                return false;
            }

            return true;
        }

        #region STATIC
        /// <summary>
        /// Extracts faces from given cycles list
        /// </summary>
        /// <param name="inputCycles">Initial list of cycles in graph 'graph'</param>
        /// <param name="network">Graph</param>
        /// <returns></returns>
        public static List<List<Vertex<Node>>> GetFaces(Graph<Node> graph, List<List<Vertex<Node>>> inputCycles)
        {
            List<List<Vertex<Node>>> resultList = new List<List<Vertex<Node>>>();
            foreach(var cycle in inputCycles)
            {
                bool bAdd = true;
                foreach (var vertex in cycle)
                {
                    List<Vertex<Node>> adjList = graph.GetAdjacentVerticesTo(vertex);
                    var commonVertices = adjList.Intersect(cycle);
                    if (commonVertices.Count() > 2)
                    {
                        bAdd = false;
                        break;
                    }
                }
                if(bAdd)
                    resultList.Add(cycle);
            }
            return resultList;
        }
        #endregion //STATIC
    }

    public enum NodeType
    {
        Unspecified = 0,
        Pump = 1,
        Container = 2,
        Reservoir = 3,
        Node = 4
    }

    [Serializable]
    public class Node
    {
        //public Dictionary<int, decimal> In;
        //public Dictionary<int, decimal> Out;
        public bool Direction; //false = normal, true - reversed
        public bool IsStartElement;
        public Point Position;
        public bool IsLocked;
        public decimal NodeLoss;
        public NodeType Type;
        
        public Node(/*Dictionary<int, decimal> i, Dictionary<int, decimal> o, */decimal nodeLoss, bool direction, NodeType type, Point coords, bool startElement = false)
        {
            //In = i;
            //Out = o;
            NodeLoss = nodeLoss;
            Direction = direction;
            IsStartElement = startElement;
            Position = coords;
            IsLocked = false;
            Type = type;
        }
        [JsonConstructor]
        public Node(Point coords)
        {
            //In = new Dictionary<int, decimal>();
            //Out = new Dictionary<int, decimal>();
            NodeLoss = 0;
            Position = coords;
            IsLocked = false;
            Type = NodeType.Node;
        }
    }

    public static class DrawHelper
    {
        /// <summary>
        /// Draws a string, roteted by given angle, using g Graphics. Leaves Graphics state unchanged.
        /// </summary>
        /// <param name="s">String to draw</param>
        /// <param name="font">Font</param>
        /// <param name="brush">Brush</param>
        /// <param name="point">Point over which string will be drawn.</param>
        /// <param name="angle">Angle in degrees</param>
        /// <param name="g">Graphics context</param>
        public static void DrawRotatedString(string s, Font font, Brush brush, PointF point, float angle, double offsetX, double offsetY, Graphics g)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(point.X, point.Y);
            g.RotateTransform(angle + 180); //because Y asis of GUI window has opposite drirection by default

            PointF newPoint = new PointF((float)offsetX, (float)offsetY);
            g.DrawString(s, font, brush, newPoint);
            g.Restore(state);
        }

        /// <summary>
        /// Draws an arrow, roteted by given angle, using g Graphics. Leaves Graphics state unchanged.
        /// </summary>
        /// <param name="pen">Pen</param>
        /// <param name="p">Beginning of the arrow.</param>
        /// <param name="length">Length of the arrow.</param>
        /// <param name="angle">Angle in degrees</param>
        /// <param name="g">Graphics context</param>
        public static void DrawRotatedArrow(Pen pen, PointF p, float length, float angle, double offsetX, double offsetY, bool reversed, Graphics g)
        {
            GraphicsState state = g.Save();
            g.TranslateTransform(p.X, p.Y);
            g.RotateTransform(angle + 180);
            Pen newPen = new Pen(pen.Color, pen.Width);
            if(!reversed)
                newPen.CustomEndCap = new AdjustableArrowCap(pen.Width * 2, pen.Width * 4);
            else
                newPen.CustomStartCap = new AdjustableArrowCap(pen.Width * 2, pen.Width * 4);
            PointF newP1 = new PointF((float)offsetX - length / 2, (float)offsetY);
            PointF newP2 = new PointF((float)offsetX + length / 2, (float)offsetY);
            g.DrawLine(newPen, newP1, newP2);
            g.Restore(state);
            newPen = null;
        }

        public static void DrawArrow(this Graphics value, Pen pen, Point pt1, Point pt2)
        {
            Pen newPen = new Pen(pen.Color, pen.Width);
            newPen.CustomEndCap = new AdjustableArrowCap(pen.Width * 4, pen.Width * 8);
            newPen.CustomStartCap = new AdjustableArrowCap(pen.Width * 4, pen.Width * 8);
            value.DrawLine(pen, pt1, pt2);
        }
    }
}
