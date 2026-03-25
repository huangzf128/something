using Common;
using DBSupporter.Common;
using DBSupporter.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DBSupporter.Common.Consts;

namespace DBSupporter
{

    public partial class Form1 : Form
    {

        private IBaseDB db = DBFactory.GetDBInstance(DBTYPE.postgresql);

        public Form1()
        {
            InitializeComponent();

            String sql = DBFactory.GetTableListSql(DBTYPE.postgresql);
            using (DbDataReader dr = db.ExecuteQuery(sql))
            {
                while (dr.Read())
                {
                    String tableName = dr.GetString(0);
                    lstTable.Items.Add(tableName);
                }
            }
        }


        #region "EVENT"

        private void lstTable_DoubleClick(object sender, EventArgs e)
        {
            string tableName = lstTable.SelectedItems[0].ToString();
            if (string.IsNullOrEmpty(tableName)) return;

            lvwColumn.Items.Clear();

            String sql = DBFactory.GetColumnListSql(DBTYPE.postgresql, tableName);
            using (DbDataReader dr = db.ExecuteQuery(sql))
            {
                while (dr.Read())
                {
                    String columnName = dr.GetString(0);
                    String columnType = dr.GetString(1);
                    String ordinalPosition = dr.GetInt32(2).ToString();
                    String isPk = dr.GetString(3);
                    lvwColumn.Items.Add(new ListViewItem(new String[] { columnName, columnType, ordinalPosition, isPk }));
                }

            }
        }


        /// <summary>
        /// Entity作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (lstTable.SelectedItems.Count == 0) return;

            string tableName = lstTable.SelectedItems[0].ToString();
            string camalTableName = StringUtil.ToPascalCase(tableName);
            String tableComment = getTableComment(tableName);


            StringBuilder sb = new StringBuilder();

            String comment = ConfigUtil.Current.CommentTemplate;
            comment = comment.Replace("{ID}", "-")
                            .Replace("{SystemName}", "")
                            .Replace("{ClassName}", $"{camalTableName}Entity")
                            .Replace("{Date}", DateTime.Now.ToString("yyyy/MM/dd"));

            sb.AppendLine(comment);

            sb.AppendLine($"@Data");
            sb.AppendLine($"@EqualsAndHashCode(callSuper = true)");
            sb.AppendLine($"@Table(value = \"{tableName}\", onInsert = {{ BaseListener.class }}, onUpdate = {{ BaseListener.class }})");
            sb.AppendLine($"public class {camalTableName}Entity extends BaseEntity implements Serializable {{");

            for (int i = 0; i < lvwColumn.Items.Count; i++)
            {
                ListViewItem column = lvwColumn.Items[i];
                String columnName = StringUtil.FirstCharToLowerCase(StringUtil.ToPascalCase(column.SubItems[0].Text));
                String columnType = column.SubItems[1].Text;
                String ordinalPosition = column.SubItems[2].Text;
                String isPk = column.SubItems[3].Text;

                // ignore common column
                if (chkIgnoreCommon.Checked && IsCommonColumn(column.SubItems[0].Text))
                {
                    continue;
                }


                String sql = $"select col_description('public.{tableName}'::regclass, {ordinalPosition})";

                String columnComment = "";
                using (DbDataReader dr = db.ExecuteQuery(sql))
                {
                    dr.Read();
                    columnComment = dr.GetString(0);
                    AddPropertyComment(sb, columnComment);
                }

                AddIdAnno(sb, isPk);
                AddColumnAnno(sb, column.SubItems[0].Text);

                if (columnType == PostgreSql.TYPE_STRING)
                {
                    sb.AppendLine($"private String {columnName};");
                }
                else if (columnType == PostgreSql.TYPE_NUMBER)
                {
                    sb.AppendLine($"private BigDecimal {columnName};");
                }
                else if (columnType == PostgreSql.TYPE_DATE)
                {
                    sb.AppendLine($"private Date {columnName};");
                }

                if (columnName.EndsWith("Kbn"))
                {
                    AddColumnForKbn(sb, columnComment, columnName + "Name");
                }
            }

            sb.Append("}");

            SaveToOutputFolder(camalTableName + "Entity.java", sb.ToString());
        }



        /// <summary>
        /// Mapper作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateMapper_Click(object sender, EventArgs e)
        {
            string tableName = lstTable.SelectedItems[0].ToString();
            string camalTableName = StringUtil.ToPascalCase(tableName);
            StringBuilder sb = new StringBuilder();

            String tableComment = getTableComment(tableName);

            sb.AppendLine("/**");
            sb.AppendLine(" * " + tableComment);
            sb.AppendLine(" */");
            sb.AppendLine($"public interface {camalTableName}Mapper extends BaseMapper<{camalTableName}Entity> {{");
            sb.AppendLine("}");

            Console.WriteLine(sb.ToString());
            //Clipboard.SetText(sb.ToString());

            SaveToOutputFolder(camalTableName + "Mapper.java", sb.ToString());


            sb.Clear();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.AppendLine("<!DOCTYPE mapper PUBLIC \"-//mybatis.org//DTD Mapper 3.0//EN\" \"http://mybatis.org/dtd/mybatis-3-mapper.dtd\">");
            sb.AppendLine($"<!-- {tableComment}マッパー -->");
            sb.AppendLine($"<mapper namespace=\"jp.c_d_c.online_shinsei.portal.mapper.common.{camalTableName}Mapper\">");

            sb.AppendLine($"<select id=\"selectList\" resultType=\"jp.c_d_c.online_shinsei.portal.entity.common.{camalTableName}Entity\">");
            sb.AppendLine(" </select>");

            sb.AppendLine("</mapper>");
            Console.WriteLine(sb.ToString());


            SaveToOutputFolder(camalTableName + "Mapper.xml", sb.ToString());
        }

        private String getTableComment(String tableName)
        {
            String sql = $"select col_description('public.{tableName}'::regclass, 0)";
            String tableComment = "";
            using (DbDataReader dr = db.ExecuteQuery(sql))
            {
                dr.Read();
                tableComment = dr.GetString(0);
            }
            return tableComment;
        }

        #endregion


        #region "METHOD"

        private bool IsCommonColumn(String columnName)
        {
            string[] commonCol = { "upd_pg_id", "upd_user_id", "upd_date", "add_pg_id", "add_user_id", "add_date", "delete_flg" };
            return commonCol.Contains(columnName);
        }

        private void AddColumnForKbn(StringBuilder sb, String columnComment, String columnName)
        {
            AddPropertyComment(sb, columnComment + "名");
            sb.AppendLine($"@Column(ignore = true)");
            sb.AppendLine($"private String {columnName};");
        }

        private void AddPropertyComment(StringBuilder sb, String columnComment)
        {
            sb.AppendLine("/**");
            sb.AppendLine($" * {columnComment}");
            sb.AppendLine(" */");
        }

        private void AddColumnAnno(StringBuilder sb, String columnName)
        {
            if (chkNumColumnAnno.Checked && columnName.Any(char.IsDigit))
            {
                sb.AppendLine($"@Column(\"{columnName}\")");
            }
        }

        private void AddIdAnno(StringBuilder sb, String isPk)
        {
            if (isPk.Equals("1"))
            {
                sb.AppendLine($"@Id");
            }
        }

        /// <summary>
        /// 将内容保存到运行目录下的 output 文件夹中
        /// </summary>
        /// <param name="fileName">文件名（例如：UserMapper.xml）</param>
        /// <param name="content">要写入的字符串内容</param>
        private void SaveToOutputFolder(string fileName, string content)
        {
            try
            {
                string outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string filePath = Path.Combine(outputDirectory, fileName);

                File.WriteAllText(filePath, content, Encoding.UTF8);

                Console.WriteLine($"output to : {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        #endregion

        private void Open_Click(object sender, EventArgs e)
        {
            string outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
            Process.Start("explorer.exe", outputDirectory);
        }
    }
}
