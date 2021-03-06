    /* ====================================================================
       Licensed to the Apache Software Foundation (ASF) under one or more
       contributor license agreements.  See the NOTICE file distributed with
       this work for additional information regarding copyright ownership.
       The ASF licenses this file to You under the Apache License, Version 2.0
       (the "License"); you may not use this file except in compliance with
       the License.  You may obtain a copy of the License at
    
           http://www.apache.org/licenses/LICENSE-2.0
    
       Unless required by applicable law or agreed to in writing, software
       distributed under the License is distributed on an "AS IS" BASIS,
       WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
       See the License for the specific language governing permissions and
       limitations under the License.
    ==================================================================== */
    
    /* ================================================================
     * Author: Tony Qu 
     * Author's email: tonyqus (at) gmail.com 
     * NPOI HomePage: http://www.codeplex.com/npoi
     * Contributors:
     * 
     * ==============================================================*/
    
    using System;
    using System.Text;
    using System.IO;
    using NPOI.HSSF.UserModel;
    using NPOI.HSSF.Util;
    using NPOI.HPSF;
    using NPOI.POIFS.FileSystem;
    using NPOI.SS.UserModel;
    
    /*
     This sample is copied from poi.hssf.usermodel.examples. Original name is Borders.java
     */
    namespace SetBorderStyleInXls
    {
        class Program
        {
            static void Main(string[] args)
            {
                InitializeWorkbook();
    
                ISheet sheet = hssfworkbook.CreateSheet("new sheet");
    
                // Create a row and put some cells in it. Rows are 0 based.
                IRow row = sheet.CreateRow(1);
    
                // Create a cell and put a value in it.
                ICell cell = row.CreateCell(1);
                cell.SetCellValue(4);
    
                // Style the cell with borders all around.
                ICellStyle style = hssfworkbook.CreateCellStyle();
                style.BorderBottom= BorderStyle.Thin;
                style.BottomBorderColor= HSSFColor.Black.Index;
                style.BorderLeft = BorderStyle.DashDotDot;
                style.LeftBorderColor= HSSFColor.Green.Index;
                style.BorderRight = BorderStyle.Hair;
                style.RightBorderColor= HSSFColor.Blue.Index;
                style.BorderTop = BorderStyle.MediumDashed;
                style.TopBorderColor= HSSFColor.Orange.Index;
                cell.CellStyle= style;
    
                // Create a cell and put a value in it.
                ICell cell2 = row.CreateCell(2);
                cell2.SetCellValue(5);
                ICellStyle style2 = hssfworkbook.CreateCellStyle();
                style2.BorderBottom = BorderStyle.Thick;
                style.BottomBorderColor = HSSFColor.Black.Index;
                cell2.CellStyle = style2;
    
                // Create a cell and put a value in it.
                ICell cell3 = row.CreateCell(3);
                cell3.SetCellValue("Something");
    
                // Create a vertically and horizontally centred cell
                row.CreateCell(3).SetCellValue("Center Hello World Hello WorldHello WorldHello WorldHello WorldHello World");
                ICellStyle styleMiddle = hssfworkbook.CreateCellStyle();
                styleMiddle.Alignment = HorizontalAlignment.Center;
                styleMiddle.VerticalAlignment = VerticalAlignment.Center;
                styleMiddle.WrapText = true; //wrap the text in the cell
                row.GetCell(3).CellStyle = styleMiddle;
                sheet.SetColumnWidth(3, 256 * 40);
    
                // Create a vertically aligned top and horizontally centred cell
                row.CreateCell(4).SetCellValue("Top Hello World Hello WorldHello WorldHello WorldHello WorldHello World");
                ICellStyle styleMiddle2 = hssfworkbook.CreateCellStyle();
                styleMiddle2.Alignment = HorizontalAlignment.Center;
                styleMiddle2.VerticalAlignment = VerticalAlignment.Top;
                styleMiddle2.WrapText = true; //wrap the text in the cell
                row.GetCell(4).CellStyle = styleMiddle2;
                sheet.SetColumnWidth(4, 256 * 40);
    
                row.Height = 1000;
    
                WriteToFile();
            }
    
    
            static HSSFWorkbook hssfworkbook;
    
            static void WriteToFile()
            {
                //Write the stream data of workbook to the root directory
                FileStream file = new FileStream(@"test.xls", FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
            }
    
            static void InitializeWorkbook()
            {
                hssfworkbook = new HSSFWorkbook();
    
                //Create a entry of DocumentSummaryInformation
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI Team";
                hssfworkbook.DocumentSummaryInformation = dsi;
    
                //Create a entry of SummaryInformation
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Subject = "NPOI SDK Example";
                hssfworkbook.SummaryInformation = si;
            }
        }
    }
