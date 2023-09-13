using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using NPOI.SS.Formula.Functions;
using System.Security.Cryptography;
using NPOI.Util;
using System.Data.OleDb;
using System.Collections;
using Org.BouncyCastle.Ocsp;

namespace _06_EXCEL
{
    public partial class Form1 : Form
    {
        public ISheet sheet;
        public FileStream fileStream;
        public IWorkbook workbook = null; //新建IWorkbook對象 
        public Form1()
        {
            InitializeComponent();
        }
        //https://einboch.pixnet.net/blog/post/274497938
        //名詞說明:
        //HSSF － 提供讀寫Microsoft Excel XLS格式檔案的功能。
        //XSSF － 提供讀寫Microsoft Excel OOXML XLSX格式檔案的功能。
        //HWPF － 提供讀寫Microsoft Word DOC格式檔案的功能。
        //HSLF － 提供讀寫Microsoft PowerPoint格式檔案的功能。
        //HDGF － 提供讀Microsoft Visio格式檔案的功能。
        //HPBF － 提供讀Microsoft Publisher格式檔案的功能。
        //HSMF － 提供讀Microsoft Outlook格式檔案的功能。
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //读取数据到DataTable，参数依此是（excel文件路径，列名对应字典，列名所在行，sheet索引）
                //DataTable dt = NPOIHelper.ImportExceltoDt(@"C:\Users\ZDZN\Desktop/Hello11.xlsx", dir, 1, 0);

                string fileName = Application.StartupPath + "\\" + "001.xlsx";
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    InitialDirectory = Application.StartupPath,
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    DataTable dataTable = LoadExcelAsDataTable(fileName);
                    if (dataGViewExcel_01.Visible && dataTable != null)
                    {
                        dataGViewExcel_01.DataSource = dataTable;
                    }
                }

            }
            catch (Exception ex)
            {
                //  throw ex;
            }
        }

        /// <summary>
        /// load Excel97/Excel2007 as DataTable
        /// </summary>
        public static DataTable LoadExcelAsDataTable(string _xlsFilename)
        {
            try
            {
                string xlsFilename = Path.Combine(
                                    Path.GetPathRoot(_xlsFilename),
                                   "TEMP_" + Path.GetFileName(_xlsFilename)
                                    );
                File.Copy(_xlsFilename, xlsFilename, true);
                FileInfo fi = new FileInfo(xlsFilename);
                using (FileStream fstream = new FileStream(fi.FullName, FileMode.Open))
                {
                    IWorkbook wb;
                    if (fi.Extension == ".xlsx")
                        wb = new XSSFWorkbook(fstream); // excel2007
                    else
                        wb = new HSSFWorkbook(fstream); // excel97

                    // 只取第一個sheet。
                    ISheet sheet = wb.GetSheetAt(0);
                    // target
                    DataTable table = new DataTable();

                    // 由第一列取標題做為欄位名稱
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum; // 取欄位數
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        //table.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue, typeof(double)));
                        table.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue));
                    }

                    // 略過第零列(標題列)，一直處理至最後一列
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;

                        DataRow dataRow = table.NewRow();

                        //依先前取得的欄位數逐一設定欄位內容
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            ICell cell = row.GetCell(j);
                            if (cell != null)
                            {
                                //如要針對不同型別做個別處理，可善用.CellType判斷型別
                                //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值

                                switch (cell.CellType)
                                {
                                    case CellType.Numeric:
                                        dataRow[j] = cell.NumericCellValue;
                                        break;
                                    default: // String
                                             //此處只簡單轉成字串
                                        dataRow[j] = cell.StringCellValue;
                                        break;
                                }
                            }
                        }

                        table.Rows.Add(dataRow);
                    }

                    File.Delete(xlsFilename);
                    // success
                    return table;
                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        public static DataTable LoadCSVAsDataTable(string _xlsFilename)
        {
            try
            {
                string xlsFilename = Path.Combine(
                                    Path.GetPathRoot(_xlsFilename),
                                   "TEMP_" + Path.GetFileName(_xlsFilename)
                                    );
                File.Copy(_xlsFilename, xlsFilename, true);
                FileInfo fi = new FileInfo(xlsFilename);

                #region 用FileStream 讀取
                //byte[] bytsize = new byte[1024 * 1024 * 5];
                //using (FileStream stream = new FileStream(xlsFilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                //{
                //    while (true)
                //    {
                //        int r = stream.Read(bytsize, 0, bytsize.Length);
                //        //如果读取到的字节数为0，说明已到达文件结尾，则退出while循
                //        if (r == 0)
                //        {
                //            break;
                //        }

                //        string str = Encoding.Default.GetString(bytsize, 0, r);
                //        Console.WriteLine(str);
                //    }
                //}
                #endregion
                List<string> ListFile = new List<string>();
                string[] StrArr = new string[0];
                using (StreamReader SR = new StreamReader(xlsFilename))
                {
                    while (SR.EndOfStream == false)
                    {
                        ListFile.Add(SR.ReadLine());
                    }
                }

                // target
                DataTable table = null;

                if (ListFile.Count > 0)
                {
                    StrArr = ListFile[0].Split(',');
                    int cellCount = StrArr.Length; // 取欄位數
                    table = new DataTable();
                    for (int i = 0; i < cellCount; i++)
                    {
                        table.Columns.Add(new DataColumn(StrArr[i]));
                    }

                    // 略過第零列(標題列)，一直處理至最後一列
                    for (int i = 1; i < ListFile.Count; i++)
                    {

                        StrArr = ListFile[i].Split(',');
                        table.Rows.Add(StrArr);

                    }

                }
                File.Delete(xlsFilename);
                // success
                return table;


            }
            catch (Exception)
            {
                return null;
                //throw;
            }



        }

        private void btnLINQ_01_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = dataGViewExcel_01.DataSource as DataTable;
                if (dataTable != null)
                {
                    int _iPower = 0;
                    string _Str;

                    var VaTESTA = dataTable.AsEnumerable().Select(D => D.Field<string>("POdsdER") == "A"); //ERROR
                    var VaTESTB = dataTable.AsEnumerable().Select(D => (D.Field<string>("POdsdER") ?? "NULL") == "NULL"); //ERROR

                    var result = dataTable.AsEnumerable().
                        Where(x => x.Field<string>("POWER") != null
                                && int.TryParse(x.Field<string>("POWER").Trim('W'), out _iPower) && _iPower > 900);
                    foreach (var item in result)
                    {
                        _Str = string.Join(",", item.ItemArray);
                        Console.WriteLine(_Str);
                        showLog(_Str);
                    }
                    showLog("-----------------------------------------------------------");
                    var resultB = from x in dataTable.AsEnumerable()
                                  where new string[] { "A1", "A2", "A5" }.Contains(x.Field<string>("EQPID").ToString())
                                  select x;

                    foreach (var item in resultB)
                    {
                        _Str = string.Join(",", item.ItemArray);
                        Console.WriteLine(_Str);
                        showLog(_Str);
                    }
                    showLog("".PadLeft(70, '-'));
                    int index = 0;
                    var resultC = from x in dataTable.AsEnumerable()
                                  where new string[] { "A2", "A3", "A5" }.Contains(x.Field<string>("EQPID").ToString())
                                  select new { x, IDX = index++ };

                    foreach (var item in resultC)
                    {
                        _Str = string.Join(",", item.x.ItemArray);
                        _Str = item.IDX + "-" + _Str;
                        Console.WriteLine(_Str);
                        showLog(_Str);
                    }

                }


            }
            catch (Exception)
            {

            }


        }

        private void showLog(string _Message)
        {
            if (listBoxLog.InvokeRequired)
            {
                listBoxLog.Invoke(new EventHandler(delegate
                {
                    showLog(_Message);
                    return;
                }));
            }
            int Max = 100;
            if (listBoxLog.Items.Count > Max)
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(listBoxLog.Items.Cast<string>().ToList().GetRange(Max / 2, listBoxLog.Items.Count - Max / 2));
                listBoxLog.Items.Clear();
                listBoxLog.Items.AddRange(tmp.ToArray());
            }


            if (_Message != "")
            {
                listBoxLog.Items.Add(_Message);
                listBoxLog.SelectedIndex = listBoxLog.Items.Count - 1;
            }



        }

        int Ai = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 150; i++)
            {
                showLog(i.ToString());
            }
        }

        private void btnLoad02_Click(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "excel files (*.csv)|*.csv|All files (*.*)|*.*"

            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                DataTable dataTableTemp = LoadCSVAsDataTable(fileName);
                DataTable dataTable = new DataTable();

                string _str = "";
                for (int i = 0; i < dataTableTemp.Columns.Count; i++)
                {
                    if (dataTableTemp.Rows.Count > 0)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = dataTableTemp.Columns[i].ColumnName.ToUpper();
                        _str = dataTableTemp.Rows[0][i] == null ? "" : dataTableTemp.Rows[0][i].ToString();


                        if (double.TryParse(_str, out _))
                        {
                            column.DataType = typeof(double);
                        }
                        else if (int.TryParse(_str, out _))
                        {
                            column.DataType = typeof(int);
                        }
                        else if (DateTime.TryParse(_str, out _))
                        {
                            column.DataType = typeof(DateTime);
                        }
                        else
                        {
                            column.DataType = typeof(string);
                        }

                        dataTable.Columns.Add(column);
                    }
                }

                object[] Objs = new object[dataTableTemp.Columns.Count];
                int tmpInt = 0;

                var Result = dataTableTemp.AsEnumerable().Select(
                    d =>
                    {
                        double tmpDou = 0;
                        DateTime DT;
                        Objs = new object[dataTableTemp.Columns.Count];
                        for (int i = 0; i < Objs.Length; i++)
                        {
                            if (dataTable.Columns[i].DataType == typeof(string))
                            {
                                Objs[i] = d.Field<string>(i);
                            }
                            else if (dataTable.Columns[i].DataType == typeof(int))
                            {
                                if (int.TryParse(d.Field<string>(i), out tmpInt))
                                {
                                    Objs[i] = Convert.ToInt32(tmpInt);
                                }
                                else
                                {
                                    Objs[i] = 0;
                                }
                            }
                            else if (dataTable.Columns[i].DataType == typeof(double))
                            {
                                if (double.TryParse(d.Field<string>(i), out tmpDou))
                                {
                                    Objs[i] = Convert.ToInt32(tmpDou);
                                }
                                else
                                {
                                    Objs[i] = 0;
                                }

                            }
                            else if (dataTable.Columns[i].DataType == typeof(DateTime))
                            {
                                if (DateTime.TryParse(d.Field<string>(i), out DT))
                                {
                                    Objs[i] = DT;
                                }
                                else
                                {
                                    Objs[i] = Convert.ToDateTime("1970/01/01");
                                }
                            }
                        }


                        return Objs;
                    }
                    );

                foreach (var item in Result)
                {
                    dataTable.Rows.Add(item);
                }

                if (dataGViewExcel_02.Visible && dataTable != null)
                {
                    dataGViewExcel_02.DataSource = dataTable.Copy();
                }
                if (dataGViewExcel_03.Visible && dataTable != null)
                {
                    dataGViewExcel_03.DataSource = dataTable.Copy();
                }
            }


        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_02.DataSource as DataTable;
            List<double> Chart_x = new List<double>();

            var XResult = dataTable.AsEnumerable().Select(d => d.Field<string>(0)).ToList();
            Chart_x = XResult.ConvertAll(d => { double D1; D1 = double.TryParse(d, out D1) ? D1 : (double)0; return D1; });
            List<string> strChart_x = new List<string>();
            strChart_x = XResult;

            List<double>[] Chart_y1 = new List<double>[dataTable.Columns.Count];
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                Chart_y1[i] = dataTable.AsEnumerable().Select(d => d.Field<string>(i)).Select(A =>
                {
                    double D1;
                    D1 = double.TryParse(A, out D1) ? D1 : (double)0;
                    return D1;
                }).ToList();
            }



            chart_02.Series.Clear();
            grpBoxSeries.Controls.Clear();
            for (int j = 1; j < dataTable.Columns.Count; j++)
            {
                chart_02.Series.Add(dataTable.Columns[j].ColumnName);
                CheckBox checkBox = new CheckBox();
                checkBox.Name = "Series" + j.ToString();
                checkBox.Text = dataTable.Columns[j].ColumnName;
                checkBox.Tag = j - 1;
                checkBox.Checked = true;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                checkBox.Left = 10;
                checkBox.Top = 30 * j + 10;
                grpBoxSeries.Controls.Add(checkBox);
                chart_02.Series[j - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                for (int i = 0; i < Chart_x.Count; i++)
                {
                    chart_02.Series[j - 1].Points.AddXY(strChart_x[i], Chart_y1[j][i]);
                }
            }

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(((CheckBox)sender).Tag.ToString(), out i))
            {
                chart_02.Series[i].Enabled = ((CheckBox)sender).Checked;
                chart_02.ChartAreas[0].RecalculateAxesScale();
            }
        }

        private void btnLINQ_03_01_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
            List<double> Chart_x = new List<double>();

            if (dataTable != null)
            {
                var XResult = dataTable.AsEnumerable().Where(d =>
                d.Field<double>("OPEN") >= 300
                ).Select(d => d);
                dataGViewResult_03.DataSource = XResult.CopyToDataTable();
            }


        }

        private void btnLINQ_03_02_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
            List<double> Chart_x = new List<double>();
            string strA = dataTable.Columns[2].ColumnName;
            string strB = dataTable.Columns[3].ColumnName;

            if (dataTable != null)
            {
                var XResult = dataTable.AsEnumerable().Where(d =>
                d.Field<double>(strA) >= 180 && d.Field<double>(strB) >= 100
                ).Select(d => d);
                dataGViewResult_03.DataSource = XResult.CopyToDataTable();
            }
        }

        private void btnLINQ_03_03_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
            List<double> Chart_x = new List<double>();
            string strA = dataTable.Columns[2].ColumnName;
            string strB = dataTable.Columns[3].ColumnName;

            string[] strArr = new string[dataTable.Columns.Count];


            if (dataTable != null)
            {
                var XResult = dataTable.AsEnumerable().Where(d =>
                d.Field<double>(strA) >= 150 && d.Field<double>(strB) >= 150
                ).Select((d, idx) => new
                {
                    d,
                    index = idx++
                });
                DataTable dataTableA = new DataTable();
                DataColumn dataColumn = new DataColumn();
                dataColumn.DataType = typeof(int);
                dataColumn.ColumnName = "Index";
                dataTableA.Columns.Add(dataColumn);
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataColumn = new DataColumn();
                    dataColumn.DataType = dataTable.Columns[i].DataType;
                    dataColumn.ColumnName = dataTable.Columns[i].ColumnName;
                    dataTableA.Columns.Add(dataColumn);
                }
                object[] objArr = new object[dataTable.Columns.Count + 1];
                List<object> objlist = new List<object>();
                object[] objArrB = new object[dataTable.Columns.Count];

                foreach (var item in XResult)
                {
                    //objlist.Add((int)item.index);

                    DataRow dataRow = dataTableA.NewRow();

                    dataRow[0] = (int)item.index;

                    for (int i = 0; i < objArrB.Length; i++)
                    {
                        dataRow[i + 1] = item.d.ItemArray[i];
                    }

                    dataTableA.Rows.Add(dataRow);

                }
                dataGViewResult_03.DataSource = dataTableA;
            }

        }

        private void btnLINQ_03_04_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
            bool B1 = false;
            DataTable result = dataTable.Copy();
            double[] dous = new double[dataTable.Columns.Count];
            for (int i = 0; i < dous.Length; i++)
            {
                dous[i] = i * 21.3;
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (dataTable.Columns[i].DataType == typeof(double))
                {
                    result = DataTableTest(result, i, dous, greater).Copy();
                }

            }

            dataGViewResult_03.DataSource = result.Copy();
        }

        private DataTable DataTableTest(DataTable _inDataTable, int _index, double[] _dous, NumberCompare Fun1)
        {
            DataTable OutDataTable;
            if (_inDataTable != null && Fun1 != null)
            {
                var Out = _inDataTable.AsEnumerable().Where(d =>
                                Fun1(d.Field<double>(_index), _dous[_index])
                                ).
                                Select(d => d);
                if (Out.Count() > 0)
                {
                    OutDataTable = Out.CopyToDataTable();
                }
                else
                {
                    OutDataTable = null;
                }

            }
            else
            {
                OutDataTable = _inDataTable;
            }
            return OutDataTable;
        }

        delegate bool NumberCompare(double X1, double X2);
        private bool greater(double X1, double X2)
        {
            return X1 > X2;
        }
        private bool Less(double X1, double X2)
        {
            return X1 < X2;
        }

        private void btnLINQ_03_05_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
            double B1 = 0;
            int iIndex = 0;
            DataTable result = dataTable.Copy();
            DataTable DT1 = dataTable.Copy();
            DT1.Rows.Clear();
            dataGViewResult_03.DataSource = DT1;

            double[] dous = new double[dataTable.Columns.Count];
            for (int i = 0; i < dous.Length; i++)
            {
                dous[i] = 0;
            }
            foreach (var item in grpB_03.Controls)
            {
                if (item is TextBox)
                {
                    if (int.TryParse(((TextBox)item).Tag.ToString(), out iIndex))
                    {
                        if (double.TryParse(((TextBox)item).Text, out B1))
                        {
                            dous[iIndex] = B1;
                        }
                        else
                        {
                            dous[iIndex] = 0;
                        }
                    }
                }
            }

            NumberCompare[] tmpdel = new NumberCompare[dataTable.Columns.Count];
            for (int i = 0; i < tmpdel.Length; i++)
            {
                tmpdel[i] = null;
            }
            foreach (var item in grpB_03.Controls)
            {
                if (item is ComboBox)
                {
                    if (int.TryParse(((ComboBox)item).Tag.ToString(), out iIndex))
                    {
                        if (((ComboBox)item).Text == "大於")
                        {
                            tmpdel[iIndex] = greater;
                        }
                        else if (((ComboBox)item).Text == "小於")
                        {
                            tmpdel[iIndex] = Less;
                        }
                    }
                }
            }

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                if (dataTable.Columns[i].DataType == typeof(double) && tmpdel[i] != null)
                {
                    result = DataTableTest(result, i, dous, tmpdel[i]);
                }

            }

            if (result != null)
            {
                dataGViewResult_03.DataSource = result.Copy();
            }
        }

        private void chkB_03_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                grpB_03.Enabled = chkB_03.Checked;
                btnLINQ_03_05.Enabled = chkB_03.Checked;
                DataTable dataTable = dataGViewExcel_03.DataSource as DataTable;
                if (dataTable == null || dataTable.Columns == null)
                {
                    grpB_03.Enabled = false;
                    btnLINQ_03_05.Enabled = false;
                    return;
                }

                int intPos = 0;
                grpB_03.Controls.Clear();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (dataTable.Columns[i].DataType == typeof(double))
                    {
                        ComboBox combo = new ComboBox();
                        combo.Name = "combo" + dataTable.Columns[i].ColumnName;
                        combo.Tag = i;
                        combo.Items.Add("None");
                        combo.Items.Add("大於");
                        combo.Items.Add("小於");
                        combo.SelectedIndex = 0;
                        combo.Left = 5;
                        combo.Top = intPos * 40 + 30;
                        combo.Width = 50;
                        grpB_03.Controls.Add(combo);
                        TextBox text = new TextBox();
                        text.Name = "txt" + dataTable.Columns[i].ColumnName;
                        text.Tag = i;
                        text.Text = "0";
                        text.Left = combo.Width + 10;
                        text.Top = intPos * 40 + 30;
                        text.Width = 90;
                        grpB_03.Controls.Add(text);
                        Label Lab = new Label();
                        Lab.Name = "Lab" + dataTable.Columns[i].ColumnName;
                        Lab.Text = dataTable.Columns[i].ColumnName;
                        Lab.Tag = i;
                        Lab.Left = 10;
                        Lab.Top = intPos * 40 + 15;
                        grpB_03.Controls.Add(Lab);
                        intPos++;
                    }
                }
            }
            catch (Exception)
            {
                grpB_03.Enabled = false;
                btnLINQ_03_05.Enabled = false;
            }
        }

        private void btnTEST04_Click(object sender, EventArgs e)
        {
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> list3 = new List<double>();

            for (int i = 0; i < 10000; i++)
            {
                list1.Add(i + i + i * 0.02 - 0.0005 * i);
                list2.Add(i * .8 + i + i * 0.51 + 0.0045 * i);
            }

            DateTime T1 = DateTime.Now;

            for (int i = 0; i < list1.Count; i++)
            {
                list3.Add(list2[i] - list1[i]);
            }

            MessageBox.Show(DateTime.Now.Subtract(T1).TotalMilliseconds.ToString());
            T1 = DateTime.Now;
            var V1 = list1.Select((d, index) => new { value = d, idx = index++ });
            var V2 = list2.Select((d, index) => new { value = d, idx = index++ });

            var V3 = (from L1 in V1
                      from L2 in V2
                      where L1.idx == L2.idx
                      select (L2.value - L1.value));

            MessageBox.Show(DateTime.Now.Subtract(T1).TotalMilliseconds.ToString());
            T1 = DateTime.Now;
            List<double> list4 = new List<double>();
            //list4 = V3.ToList();
            foreach (var item in V3)
            {
                // list4.Add(item);
            }

            MessageBox.Show(DateTime.Now.Subtract(T1).TotalMilliseconds.ToString());

        }

        private void btnLoadExcel_05_Click(object sender, EventArgs e)
        {
            
            try
            {

                string fileName = Application.StartupPath + "\\" + "001.xlsx";
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    InitialDirectory = Application.StartupPath,
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    DataTable dataTable = LoadExcelOBDCAsDataTable(fileName);
                    if (dataGViewExcel_05.Visible && dataTable != null)
                    {
                        dataGViewExcel_05.DataSource = dataTable;
                    }

                }
            }
            catch (Exception ex)
            {
            
            }
        }


        public static DataTable LoadExcelOBDCAsDataTable(string _xlsFilename)
        {
            //https://zhuanlan.zhihu.com/p/566423292
            //调试代码，在conn.Open打开链接时出错。修改链接字符串，调试发现可能Excel版本问题，Exce连接字符串版本是xls(2003或以前版本），更改为Excel2007版本则正常导入。

            //strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath("ExcelFiles/MyExcelFile.xls") + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2003或之前版本(.xls)文件
            //改为
            //strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Server.MapPath("ExcelFiles/Mydata2007.xlsx") + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (同时支持Excel2003 和 Excel2007 的连接字符串)

            //如果不能使用ace.oledb.12.0, 则要先安装Microsoft Database Engine会修复错误。 此代码适用于Office 2010 / 2013。
           // try
            {
                string xlsFilename = Path.Combine(
                                    Path.GetPathRoot(_xlsFilename),
                                   "TEMP_" + Path.GetFileName(_xlsFilename)
                                    );
                File.Copy(_xlsFilename, xlsFilename, true);

                string strConn;
              //   strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + xlsFilename + ";" + "Extended Properties=Excel 8.0;";
                 strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + xlsFilename + ";" + "Extended Properties='Excel 12.0;'";
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
                conn.Open();

                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                DataTable table = new DataTable();
              
                strExcel = "select * from [sheet1$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                //DataSet ds = null; ds = new DataSet();
                //myCommand.Fill(ds, "table1");
                myCommand.Fill(table);
                // success
                return table;

            }
         //   catch (Exception)
            //{

            //    throw;
            //}



        }

        private void btnLoad06_Click(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Application.StartupPath,
                Filter = "excel files (*.csv)|*.csv|All files (*.*)|*.*"

            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                DataTable dataTableTemp = LoadCSVAsDataTable(fileName);
                DataTable dataTable = new DataTable();

                string _str = "";
                for (int i = 0; i < dataTableTemp.Columns.Count; i++)
                {
                    if (dataTableTemp.Rows.Count > 0)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = dataTableTemp.Columns[i].ColumnName.ToUpper();
                        _str = dataTableTemp.Rows[0][i] == null ? "" : dataTableTemp.Rows[0][i].ToString();


                        if (double.TryParse(_str, out _))
                        {
                            column.DataType = typeof(double);
                        }
                        else if (int.TryParse(_str, out _))
                        {
                            column.DataType = typeof(int);
                        }
                        else if (DateTime.TryParse(_str, out _))
                        {
                            column.DataType = typeof(DateTime);
                        }
                        else
                        {
                            column.DataType = typeof(string);
                        }

                        dataTable.Columns.Add(column);
                    }
                }

                object[] Objs = new object[dataTableTemp.Columns.Count];
                int tmpInt = 0;

                var Result = dataTableTemp.AsEnumerable().Select(
                    d =>
                    {
                        double tmpDou = 0;
                        DateTime DT;
                        Objs = new object[dataTableTemp.Columns.Count];
                        for (int i = 0; i < Objs.Length; i++)
                        {
                            if (dataTable.Columns[i].DataType == typeof(string))
                            {
                                Objs[i] = d.Field<string>(i);
                            }
                            else if (dataTable.Columns[i].DataType == typeof(int))
                            {
                                if (int.TryParse(d.Field<string>(i), out tmpInt))
                                {
                                    Objs[i] = Convert.ToInt32(tmpInt);
                                }
                                else
                                {
                                    Objs[i] = 0;
                                }
                            }
                            else if (dataTable.Columns[i].DataType == typeof(double))
                            {
                                if (double.TryParse(d.Field<string>(i), out tmpDou))
                                {
                                    Objs[i] = Convert.ToInt32(tmpDou);
                                }
                                else
                                {
                                    Objs[i] = 0;
                                }

                            }
                            else if (dataTable.Columns[i].DataType == typeof(DateTime))
                            {
                                if (DateTime.TryParse(d.Field<string>(i), out DT))
                                {
                                    Objs[i] = DT;
                                }
                                else
                                {
                                    Objs[i] = Convert.ToDateTime("1970/01/01");
                                }
                            }
                        }


                        return Objs;
                    }
                    );

                foreach (var item in Result)
                {
                    dataTable.Rows.Add(item);
                }

                if (dataGViewExcel_06.Visible && dataTable != null)
                {
                    dataGViewExcel_06.DataSource = dataTable.Copy();
                }
                

            }

        }

        private void btnLINQ_06_01_Click(object sender, EventArgs e)
        {
            DataTable dataTable = dataGViewExcel_06.DataSource as DataTable;
            List<double> Chart_x = new List<double>();

            if (dataTable != null)
            {
               // var XResult = dataTable.AsEnumerable().GroupBy(b => new { EQPMODEL = b.Field<string>("EQPMODEL"), EQPID = b.Field<string>("POWER") } )
                var XResult = dataTable.AsEnumerable().GroupBy(b => new { EQPMODEL = b.Field<string>("EQPMODEL") } )
       .                SelectMany(g => g.OrderBy(c => c.Field<string>("EQPID")).
                        Select((b, i) => new { EQPID= b.Field<string>("EQPID"), EQPMODEL = b.Field<string>("EQPMODEL"), POWER = b.Field<string>("POWER"), rn = i + 1 }));
                DataTable dataTableB = new DataTable();

                DataColumn dataColumn = new DataColumn();
                dataColumn.ColumnName = "EQPID";
                dataColumn.DataType = typeof(string);
                dataTableB.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "EQPMODEL";
                dataColumn.DataType = typeof(string);
                dataTableB.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "POWER";
                dataColumn.DataType = typeof(string);
                dataTableB.Columns.Add(dataColumn);
                dataColumn = new DataColumn();
                dataColumn.ColumnName = "idx";
                dataColumn.DataType = typeof(decimal);
                dataTableB.Columns.Add(dataColumn);

                foreach (var item in XResult)
                {
                    dataTableB.Rows.Add(new object[] { item.EQPID, item.EQPMODEL, item.POWER , item.rn });
                }

                dataGViewExcel_06_02.DataSource = dataTableB;

               // var results = XResult.ToList();
            }

    
      

          


        }



    }




}
