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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {  
                //读取数据到DataTable，参数依此是（excel文件路径，列名对应字典，列名所在行，sheet索引）
                //DataTable dt = NPOIHelper.ImportExceltoDt(@"C:\Users\ZDZN\Desktop/Hello11.xlsx", dir, 1, 0);

                string fileName = Application.StartupPath + "\\" + "001.xlsx";
                OpenFileDialog openFileDialog = new OpenFileDialog() { 
                    InitialDirectory = Application.StartupPath,
                    Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    DataTable dataTable = LoadExcelAsDataTable(fileName);
                    if (dataGViewExcel_01.Visible)
                    {
                        dataGViewExcel_01.DataSource = dataTable;
                    }
                    if (dataGViewExcel_02.Visible)
                    {
                        dataGViewExcel_02.DataSource = dataTable;
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
            string xlsFilename = Path.Combine(
                                Path.GetPathRoot(_xlsFilename),
                               "TEMP_" + Path.GetFileName(_xlsFilename)
                                ) ;
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

        private void btnLINQ_01_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = dataGViewExcel_01.DataSource as DataTable;
                if (dataTable != null)
                {
                    int _iPower = 0;
                    string _Str;

                    var VaTESTA =  dataTable.AsEnumerable().Select(D =>  D.Field<string>("POdsdER") == "A"); //ERROR
                    var VaTESTB =  dataTable.AsEnumerable().Select(D =>  (D.Field<string>("POdsdER") ?? "NULL") == "NULL"); //ERROR

                    var result = dataTable.AsEnumerable().
                        Where(x => x.Field<string>("POWER") != null 
                                &&  int.TryParse( x.Field<string>("POWER").Trim('W'),out  _iPower) && _iPower > 900);
                    foreach (var item in result)
                    {
                        _Str = string.Join(",", item.ItemArray);
                        Console.WriteLine(_Str);
                        showLog(_Str);
                    }
                    showLog("-----------------------------------------------------------");
                    var resultB =from x in  dataTable.AsEnumerable()
                                 where new string[] { "A1", "A2","A5" }.Contains( x.Field<string>("EQPID").ToString()) 
                                 select x ;

                    foreach (var item in resultB)
                    {
                        _Str = string.Join(",", item.ItemArray);
                        Console.WriteLine(_Str);
                        showLog(_Str);
                    }
                    showLog("".PadLeft(70,'-'));
                    int index = 0;
                    var resultC = from x in dataTable.AsEnumerable()
                                  where new string[] { "A2", "A3", "A5" }.Contains(x.Field<string>("EQPID").ToString())
                                  select new { x, IDX = index ++ };

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
                listBoxLog.Invoke(new EventHandler( delegate {
                    showLog(_Message);
                    return;
                }));
            }
            int Max = 100;
            if (listBoxLog.Items.Count > Max)
            {
                List<string> tmp = new List<string>();
                tmp.AddRange(listBoxLog.Items.Cast<string>().ToList().GetRange(Max / 2 , listBoxLog.Items.Count - Max / 2));
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
    }


   
}
