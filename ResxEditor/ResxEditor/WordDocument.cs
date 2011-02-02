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
using ResxEditor.Forms;
using ResxEditor.Helpers;
using Orientation = Novacode.Orientation;

namespace ResxEditor
{
    /// <summary>
    ///   This class handles word documents in the docx format, i.e. importing and exporting to it.
    /// </summary>
    public class WordDocument
    {
        private static readonly string TitleComment = LangHandler.GetString("titleComment");
        private static readonly string TitleScreenshot = LangHandler.GetString("titleScreenshot");

        private readonly DataGridView gridView;
        private readonly int columns;
        private readonly int rows;
        private readonly string title;

        public string FilePath { get; private set; }

        public WordDocument(DataGridView gridView)
        {
            this.gridView = gridView;
            columns = gridView.Columns.Count;
            rows = gridView.Rows.Count;

            FileInfo fileInfo = new FileInfo(gridView.Columns[1].Name);
            string filename = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("."));
            title = filename;
            FilePath = Path.Combine(fileInfo.DirectoryName, filename + ".docx");
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

            bool update = File.Exists(FilePath);
            if (update)
            {
                document = DocX.Load(FilePath);
                table = document.Tables.First();
            }
            else
            {
                document = DocX.Create(FilePath);
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
            table.SetCellText(TitleComment, 0, columns).Bold(); // TODO localize
            table.SetCellText(TitleScreenshot, 0, columns + 1).Bold(); // TODO localize

            for (int i = 0; i < rows; i++)
            {
                if (!gridView.Rows[i].IsNewRow)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Paragraph paragraph =
                            table.SetCellText(gridView.Rows[i].Cells[j].EditedFormattedValue.ToString(), i + 1, j);
                        if (j == 0)
                        {
                            paragraph.Bold().Highlight(Highlight.lightGray);
                        }
                    }
                }
            }

            // remove spare rows
            for (int i = rows + 1; i <= table.RowCount; i++)
            {
                table.RemoveRow(i - 1);
            }

            if (!update)
            {
                document.InsertTable(table);
            }

            document.Save();
            document.Dispose();
        }

        /// <summary>
        ///   Exports to a word file. The file is saved to the specified <paramref name = "filePath" />.
        ///   If the file already exists, the translations are updated, without changing the comments
        ///   and screenshots or any other modification made to the word document outside of the translation
        ///   table.
        /// </summary>
        /// <param name = "filePath">The file path.</param>
        public void Export(string filePath)
        {
            FilePath = filePath;
            Export();
        }

        /// <summary>
        ///   Imports the translations from a word file. The file is loaded from the directory where the resx files
        ///   are located. The filename corresponds to the name of the resx files, without the locale identifier.
        /// </summary>
        public void Import()
        {
            using (DocX document = DocX.Load(FilePath))
            {
                Table table = document.Tables.First();

                for (int i = 0; i < table.RowCount - 1; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        string importText = table.GetCellText(i + 1, j);
                        string originalText = (gridView.Rows[i].Cells[j].EditedFormattedValue ?? "").ToString();
                        if (importText != originalText)
                        {
                            gridView.Rows[i].Cells[j].Value = importText;
                        }
                    }
                }

                // remove spare rows
                for (int i = rows - 1; i >= table.RowCount - 1; i--)
                {
                    if (!gridView.Rows[i].IsNewRow)
                    {
                        gridView.Rows.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        ///   Imports the translations from a word file. The file is loaded from the specified <paramref name = "filePath" />.
        /// </summary>
        /// <param name = "filePath">The file path.</param>
        public void Import(string filePath)
        {
            FilePath = filePath;
            Import();
        }
    }
}
