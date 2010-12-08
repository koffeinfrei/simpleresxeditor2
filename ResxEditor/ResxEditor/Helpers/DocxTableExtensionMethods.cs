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

using System;
using System.Linq;
using Novacode;

namespace ResxEditor.Helpers
{
    /// <summary>
    /// Extension methods for the <see cref="Paragraph"/> class from the <see cref="DocX"/> library.
    /// </summary>
    public static class DocxTableExtensionMethods
    {
        /// <summary>
        /// Sets the cell text, i.e. replaces the existing text or inserts it if none is present.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="text">The text.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns></returns>
        public static Paragraph SetCellText(this Table table, string text, int row, int col)
        {
            Paragraph paragraph = table.Rows[row].Cells[col].Paragraphs.First();

            if (!string.IsNullOrEmpty(paragraph.Text))
            {
                paragraph.RemoveText(0, false);
            }
            return paragraph.Append(text);
        }

        /// <summary>
        /// Gets the joined cell text of all the paragraphs inside the table cell.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <returns></returns>
        public static string GetCellText(this Table table, int row, int col)
        {
            return string.Join(Environment.NewLine, table.Rows[row].Cells[col].Paragraphs.Select(p => p.Text).ToArray());
        }
    }
}
