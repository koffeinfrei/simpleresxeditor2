//  simpleresxeditor
//  Copyright (C) 2010  Alexis Reigel
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.IO;
using System.Linq;
using System.Windows.Forms;
using Novacode;
using ResxEditor.Helpers;
using Orientation = Novacode.Orientation;

namespace ResxEditor
{
    /// <summary>
    ///   This class handles word documents in the docx format, i.e. importing and exporting to it.
    /// </summary>
    public class WordDocument
    {
        private readonly DataGridView gridView;
        private readonly int columns;
        private readonly int rows;
        private readonly string title;
        private readonly string filepath;

        public WordDocument(DataGridView gridView)
        {
            this.gridView = gridView;
            columns = gridView.Columns.Count;
            rows = gridView.Rows.Count;

            FileInfo fileInfo = new FileInfo(gridView.Columns[1].Name);
            string filename = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("."));
            title = filename;
            filepath = Path.Combine(fileInfo.DirectoryName, filename + ".docx");
        }


        /// <summary>
        ///   Exports to a word file. The file is saved into the directory where the resx files
        ///   are located. The filename corresponds to the name of the resx files, without the locale identifier.
        ///   If the file already exists, the translations are updated, without changing the comments
        ///   and screenshots or any other modification made to the word document outside of the translation
        ///   table.
        /// </summary>
        public void Export()
        {
            DocX document;
            Table table;

            bool update = File.Exists(filepath);
            if (update)
            {
                document = DocX.Load(filepath);
                table = document.Tables.First();
            }
            else
            {
                document = DocX.Create(filepath);
                document.InsertParagraph().Append(title).Bold().AppendLine();
                document.PageLayout.Orientation = Orientation.Landscape;

                table = document.AddTable(rows + 1, columns + 2);
                table.Design = TableDesign.TableGrid;
            }

            // set header
            for (int i = 0; i < columns; i++)
            {
                table.SetCellText(gridView.Columns[i].Tag.ToString(), 0, i).Bold().CapsStyle(CapsStyle.caps);
            }
            table.SetCellText("Comment", 0, columns).Bold(); // TODO localize
            table.SetCellText("Screenshot", 0, columns + 1).Bold(); // TODO localize

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!gridView.Rows[i].IsNewRow)
                    {
                        Paragraph paragraph = table.SetCellText(gridView.Rows[i].Cells[j].Value.ToString(), i + 1, j);
                        if (j == 0)
                        {
                            paragraph.Bold().Highlight(Highlight.lightGray);
                        }
                    }
                }
            }

            if (!update)
            {
                document.InsertTable(table);
            }

            document.Save();
            document.Dispose();
        }

        /// <summary>
        ///   Imports the translations from a word file. The file is loaded from the directory where the resx files
        ///   are located. The filename corresponds to the name of the resx files, without the locale identifier.
        /// </summary>
        public void Import()
        {
            using (DocX document = DocX.Load(filepath))
            {
                Table table = document.Tables.First();

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        string importText = table.GetCellText(i + 1, j);
                        string originalText = (gridView.Rows[i].Cells[j].Value ?? "").ToString();
                        if (importText != originalText)
                        {
                            gridView.Rows[i].Cells[j].Value = importText;
                        }
                    }
                }
            }
        }
    }
}
