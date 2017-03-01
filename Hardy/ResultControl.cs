using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardy
{
    public partial class ResultControl : UserControl
    {
        #region STRING CONSTANTS
        public static readonly string COL_RING = "Pierscien";
        public static readonly string COL_PIPE = "Odcinek";
        public static readonly string COL_DIA = "Srednica";
        public static readonly string COL_LENGTH = "Dlugosc";
        public static readonly string COL_QS = "Q na poczatku odcinka Qp";
        public static readonly string COL_QE = "Q na koncu odcinka Qk";
        public static readonly string COL_QO = "Zużycie na odcinku Qo";
        public static readonly string COL_SIGN = "Znak";
        public static readonly string COL_Q1 = "Q1";
        public static readonly string COL_DELTAH = "Δh";
        public static readonly string COL_DELTAQ = "ΔQ";
        public static readonly string COL_C = "c";
        public static readonly string COL_K = "k";
        public static readonly string COL_kQ = "k * Q";
        #endregion //STRING CONSTANTS
        #region MEMBERS
        private static readonly decimal EPSILON = 0.03M;
        private DataTable dataTable = new DataTable();
        #endregion //MEMBERS

        #region PROPERTIES
        public DataTable Table
        {
            get
            {
                return dataTable;
            }
        }
        #endregion //PROPERTIES

        #region INITIALIZATION
        public ResultControl()
        {
            InitializeComponent();
        }

        private void ClearAndPrepareBasicColumns()
        {
            dataTable.Rows.Clear();
            dataTable.Columns.Clear();
            dataTable.Columns.Add(COL_RING);
            dataTable.Columns.Add(COL_PIPE);
            dataTable.Columns.Add(COL_DIA);
            dataTable.Columns.Add(COL_LENGTH);
            dataTable.Columns.Add(COL_C);
            dataTable.Columns.Add(COL_K);
            dataTable.Columns.Add(COL_QS);
            dataTable.Columns.Add(COL_QE);
            dataTable.Columns.Add(COL_QO);
            dataTable.Columns.Add(COL_Q1);
            dataTable.Columns.Add(COL_kQ);
            dataTable.Columns.Add(COL_SIGN);
            dataTable.Columns.Add(COL_DELTAH);
        }
        #endregion //INITIALIZATION

        public void Calculate(Graph<Node> network)
        {
            ClearAndPrepareBasicColumns();
            bool bError = false;
            List<List<Vertex<Node>>> cycles = GetLoops(network);
            List<Loop> loops = new List<Loop>();
            foreach (var cycle in cycles)
            {
                List<Pipe> pipes = GetPipes(network, cycle);
                InitialNodeDialog ind = new InitialNodeDialog(pipes);
                if(ind.ShowDialog() == DialogResult.OK)
                    loops.Add(new Loop { InitialPipe = ind.SelectedPipe, Pipes = pipes });
            }


            //Filling grid with data - 1st iteration
            Dictionary<Loop, Tuple<decimal, decimal>> hQResults = new Dictionary<Loop, Tuple<decimal, decimal>>();
            
            for (int idxLoop = 0; idxLoop < loops.Count(); idxLoop++)
            {
                var pipes = loops[idxLoop].Pipes;
                Pipe initial = loops[idxLoop].InitialPipe;
                Pipe current = initial;
                decimal sumDeltaH = 0;
                decimal sumKQ = 0;
                while (true)
                {
                    string ring = (idxLoop + 1).ToString();
                    decimal dia = current.Edg.Diameter;
                    decimal length = current.Edg.Length;
                    decimal c = current.Edg.C;
                    decimal k = length * c;
                    decimal qs = current.Edg.Qstart;
                    decimal qe = current.Edg.Qend;
                    decimal qo = current.Edg.PipeLoss;
                    //decimal q55 = (qe + 0.55M * qo) * 0.001M;
                    decimal q1 = (qe + 0.55M * qo);
                    decimal sign = current.Edg.Sign;
                    if(idxLoop > 0)
                    {
                        Loop prevLoop = loops[idxLoop - 1];
                        List<Edge<Node>> edgs = prevLoop.Pipes.Select(p => p.Edg).ToList();
                        if (edgs.Any(v => (v.Beginning.Index == current.Edg.Beginning.Index && v.End.Index == current.Edg.End.Index)
                        || v.Beginning.Index == current.Edg.End.Index && v.End.Index == current.Edg.Beginning.Index))
                            sign = -sign;
                    }
                    //1st iteration
                    // decimal q1 = (qe + q55) * 0.001M;
                    decimal q1metry = q1 * 0.001M;
                    decimal qDziwne = q1metry * sign;
                    decimal deltaH = sign * k * qDziwne * qDziwne;
                    deltaH = Decimal.Round(deltaH, 4, MidpointRounding.AwayFromZero);
                    sumDeltaH += deltaH;
                    sumKQ += k * qDziwne;

                    DataRow newRow = dataTable.NewRow();
                    //setting values
                    newRow[COL_RING] = ring;
                    newRow[COL_PIPE] = current.Label;
                    newRow[COL_DIA] = dia;
                    newRow[COL_LENGTH] = length;
                    newRow[COL_C] = c;
                    newRow[COL_K] = k;
                    newRow[COL_QS] = qs;
                    newRow[COL_QE] = qe;
                    newRow[COL_QO] = qo;
                    newRow[COL_Q1] = q1metry;
                    newRow[COL_kQ] = Decimal.Round(k * qDziwne, 4, MidpointRounding.AwayFromZero);
                    newRow[COL_SIGN] = sign;
                    newRow[COL_DELTAH] = deltaH;
                    dataTable.Rows.Add(newRow);

                    current = current.Next;
                    if (current == initial)
                        break;
                }

                decimal deltaQ = -sumDeltaH / (2 * sumKQ);
                hQResults.Add(loops[idxLoop], Tuple.Create(sumDeltaH, deltaQ));

                DataRow drDeltaQ = dataTable.NewRow();
                DataRow drSumDeltaH = dataTable.NewRow();
                DataRow drSumkq = dataTable.NewRow();
                drDeltaQ[COL_RING] = idxLoop + 1;
                drDeltaQ[COL_QO] = "ΔQ1:";
                drDeltaQ[COL_Q1] = Decimal.Round(deltaQ, 4, MidpointRounding.AwayFromZero);
                drSumDeltaH[COL_RING] = idxLoop + 1;
                drSumDeltaH[COL_QO] = "ΣΔh1:";
                drSumDeltaH[COL_Q1] = Decimal.Round(sumDeltaH, 4, MidpointRounding.AwayFromZero);
                drSumkq[COL_RING] = idxLoop + 1;
                drSumkq[COL_QO] = "ΣkQ1:";
                drSumkq[COL_Q1] = Decimal.Round(sumKQ, 4, MidpointRounding.AwayFromZero);
                dataTable.Rows.Add(drDeltaQ);
                dataTable.Rows.Add(drSumDeltaH);
                dataTable.Rows.Add(drSumkq);
            }

            //iterating until ΣΔh < 0.5 for each loop
            List<string> QiLabels = new List<string>();
            QiLabels.Add(COL_Q1);
            int i = 1;
            while(true)
            {
                i++;
                int doneLoops = 0;

                string qiColLabel = "Q" + i;
                string deltaHColLabel = "Δh" + i;
                string kQColLabel = "k*Q" + i;
                dataTable.Columns.Add(qiColLabel);
                dataTable.Columns.Add(deltaHColLabel);
                dataTable.Columns.Add(kQColLabel);
                for (int idxLoop = 0; idxLoop < loops.Count(); idxLoop++)
                {
                    
                    Loop loop = loops[idxLoop];
                    decimal prevDeltaQ = hQResults[loop].Item2;
                    decimal prevDeltaH = hQResults[loop].Item1;

                    if (Math.Abs(prevDeltaH) < EPSILON)
                    {
                        doneLoops++;
                        continue;
                    }

                    decimal sigmaDeltaHi = 0M;
                    decimal sigmaKQ = 0M;

                    Pipe initialPipe = loop.InitialPipe;
                    Pipe currentPipe = initialPipe;
                    while (true)
                    {
                        string label = currentPipe.Label;
                        string query = COL_PIPE + " = '" + label + "'";
                        DataRow dr = dataTable.Select(query).First();
                        string prevQiColLabel = "Q" + (i - 1);
                        decimal k = Decimal.Parse(dr[COL_K].ToString());
                        decimal prevQ = Decimal.Parse(dr[prevQiColLabel].ToString());
                        decimal sign = currentPipe.Edg.Sign;

                        if (idxLoop > 0)
                        {
                            Loop prevLoop = loops[idxLoop - 1];
                            List<Edge<Node>> edgs = prevLoop.Pipes.Select(p => p.Edg).ToList();
                            if (edgs.Any(v => (v.Beginning.Index == currentPipe.Edg.Beginning.Index && v.End.Index == currentPipe.Edg.End.Index)
                            || v.Beginning.Index == currentPipe.Edg.End.Index && v.End.Index == currentPipe.Edg.Beginning.Index))
                                sign = -sign;
                        }

                        decimal qi = prevQ * sign + prevDeltaQ;
                        decimal deltaH = sign * k * qi * qi;
                        sigmaDeltaHi += deltaH;
                        sigmaKQ += k * qi;
                        
                        dr[qiColLabel] = Decimal.Round(qi, 4, MidpointRounding.AwayFromZero);
                        dr[deltaHColLabel] = Decimal.Round(deltaH, 4, MidpointRounding.AwayFromZero);
                        dr[kQColLabel] = Decimal.Round(k*qi, 4, MidpointRounding.AwayFromZero);
                        dataTable.AcceptChanges();
                        currentPipe = currentPipe.Next;
                        if (i > 0 && currentPipe == initialPipe)
                            break;
                    }
                    decimal deltaQ = -sigmaDeltaHi / (2 * sigmaKQ);
                    hQResults[loop] = Tuple.Create(sigmaDeltaHi, deltaQ);

                    string q = COL_RING + " = '" + (idxLoop + 1) + "' AND " + COL_PIPE + " IS NULL";
                    DataRow[] additionalRows = dataTable.Select(q);
                    DataRow drDeltaQ = additionalRows[0];
                    DataRow drSumDeltaH = additionalRows[1];
                    DataRow drSumkq = additionalRows[2];

                    drDeltaQ[qiColLabel] = "Δ" + qiColLabel;
                    drDeltaQ[deltaHColLabel] = Decimal.Round(deltaQ, 4, MidpointRounding.AwayFromZero);

                    drSumDeltaH[qiColLabel] = "Σ" + deltaHColLabel;
                    drSumDeltaH[deltaHColLabel] = Decimal.Round(sigmaDeltaHi, 4, MidpointRounding.AwayFromZero);

                    drSumkq[qiColLabel] = "Σ" + kQColLabel;
                    drSumkq[deltaHColLabel] = Decimal.Round(sigmaKQ, 4, MidpointRounding.AwayFromZero);

                }

                QiLabels.Add(qiColLabel);

                if (doneLoops == loops.Count)
                {
                    dataTable.Columns.Remove(qiColLabel);
                    dataTable.Columns.Remove(deltaHColLabel);
                    dataTable.Columns.Remove(kQColLabel);
                    QiLabels.Remove(QiLabels.Last());
                    break;
                }

                if(i > 20)
                {
                    MessageBox.Show("Timeout! Program się zapętlił w obliczeniach i wyliczył ponad 100 poprawek!\n\rPrawdopodobnie dane wejściowe są nieprawidłowe...", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bError = true;
                    break;
                }
            }
            if(!bError)
            {
                string qpLabel = "Qp";
                string qkLabel = "Qk";
                dataTable.Columns.Add(qpLabel);
                dataTable.Columns.Add(qkLabel);
                foreach(DataRow dr in dataTable.Rows)
                {
                    string stringVal = dr[QiLabels.Last()].ToString();
                    decimal parsedVal = 0;
                    if(Decimal.TryParse(stringVal, out parsedVal))
                    {
                        decimal Q0 = Decimal.Parse(dr[COL_QO].ToString()) * 0.001M;
                        decimal qKoncowe = parsedVal - 0.55M * Q0;
                        decimal qPoczatkowe = qKoncowe + Q0;
                        dr[qpLabel] = qPoczatkowe;
                        dr[qkLabel] = qKoncowe;
                    }
                }
            }
            dgvResults.DataSource = dataTable;
        }

        private List<List<Vertex<Node>>> GetLoops(Graph<Node> net)
        {
            List<List<Vertex<Node>>> res = new List<List<Vertex<Node>>>();
            int[][] data = net.AsListOfEdges();
            akCyclesInUndirectedGraphs.CyclesHelper.SetGraph(data);
            List<string> ret = akCyclesInUndirectedGraphs.CyclesHelper.demo();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ret.Count(); i++)
            {
                List<Vertex<Node>> currentVertices = new List<Vertex<Node>>();
                string cycle = ret[i];
                string[] vertices = cycle.Split(',');
                foreach (string v in vertices)
                {
                    int num = 0;
                    if (Int32.TryParse(v, out num))
                    {
                        Vertex<Node> vertex = net.Vertices.Where(x => x.Index == num).First();
                        currentVertices.Add(vertex);
                    }
                }
                res.Add(currentVertices);
                //string line = "Loop " + (i + 1) + ": " + ret[i];
                //sb.AppendLine(line);
            }
            //MessageBox.Show(sb.ToString());
            res = PipeModel.GetFaces(net, res);
            return res;
        }

        private List<Pipe> GetPipes(Graph<Node> network, List<Vertex<Node>> cycle)
        {
            List<Pipe> pipes = new List<Pipe>();
            Vertex<Node> initialVertex = cycle[0];
            Vertex<Node> currentVertex = initialVertex;
            Vertex<Node> prevVertex = null;
            while (true)
            {
                List<Vertex<Node>> adjList = network.GetAdjacentVerticesTo(currentVertex);
                List<Vertex<Node>> intersect = adjList.Intersect(cycle).ToList();
                Vertex<Node> nextVertex = null;
                if (currentVertex != initialVertex)
                    nextVertex = intersect.Where(v => v != prevVertex).First();
                else
                    nextVertex = intersect.First();
                Pipe p = new Pipe();
                p.Edg = network.Edges[currentVertex.Index - 1][nextVertex.Index - 1];


                if (p.Edg.Sign > -1)
                {
                    p.Begin = currentVertex;
                    p.End = nextVertex;
                }
                else
                {
                    p.Begin = nextVertex;
                    p.End = currentVertex;
                }
                p.Label = p.Begin.Index + "," + p.End.Index;

                if (pipes.Count() > 0)
                {
                    Pipe prev = pipes.Last();
                    p.Prev = pipes.Last();
                    pipes.Last().Next = p;
                }
                pipes.Add(p);

                prevVertex = currentVertex;
                currentVertex = nextVertex;
                if (nextVertex == initialVertex)
                {
                    p.Next = pipes.First();
                    break;
                }
            }
            
            return pipes;
        }
    }

    public class Pipe
    {
        public string Label { get; set; }
        public Vertex<Node> Begin;
        public Vertex<Node> End;
        public Edge<Node> Edg;
        public Pipe Prev;
        public Pipe Next;
    }

    internal struct Loop
    {
        public Pipe InitialPipe;
        public List<Pipe> Pipes;
    }
}