using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Serein.Base
{
    internal partial class PluginManager
    {
        public static string PluginPath = string.Empty;
        public static bool Available = true;
        public static string[] Get()
        {
            if (File.Exists(Global.Settings.Server.Path))
            {
                Available = true;
                if (Directory.Exists(Path.GetDirectoryName(Global.Settings.Server.Path) + "\\plugin"))
                {
                    PluginPath = Path.GetDirectoryName(Global.Settings.Server.Path) + "\\plugin";
                }
                else if (Directory.Exists(Path.GetDirectoryName(Global.Settings.Server.Path) + "\\plugins"))
                {
                    PluginPath = Path.GetDirectoryName(Global.Settings.Server.Path) + "\\plugins";
                }
                else if (Directory.Exists(Path.GetDirectoryName(Global.Settings.Server.Path) + "\\mod"))
                {
                    PluginPath = Path.GetDirectoryName(Global.Settings.Server.Path) + "\\mod";
                }
                else if (Directory.Exists(Path.GetDirectoryName(Global.Settings.Server.Path) + "\\mods"))
                {
                    PluginPath = Path.GetDirectoryName(Global.Settings.Server.Path) + "\\mods";
                }
                else
                {
                    PluginPath = Global.Path;
                    Available = false;
                    return null;
                }
                if (!string.IsNullOrWhiteSpace(PluginPath))
                {
                    string[] Files = Directory.GetFiles(PluginPath, "*", SearchOption.TopDirectoryOnly);
                    return Files;
                }
            }
            else
            {
                Available = false;
            }
            return null;
        }
        public static void Add()
        {
            OpenFileDialog Dialog = new OpenFileDialog()
            {
                Filter = "所有文件|*.*",
                Multiselect = true
            };
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string FileName in Dialog.FileNames)
                {
                    try
                    {
                        File.Copy(FileName, PluginPath + "\\" + Path.GetFileName(FileName));
                    }
                    catch (Exception Exp)
                    {
                        MessageBox.Show(
                            $"文件\"{FileName}\"复制失败\n" +
                            $"详细原因：\n" +
                            $"{Exp.Message}", "Serein",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                            );
                    }
                }
            }
        }
        public static void Add(List<string> Files)
        {
            foreach (string FileName in Files)
            {
                try
                {
                    File.Copy(FileName, PluginPath + "\\" + Path.GetFileName(FileName));
                }
                catch (Exception Exp)
                {
                    MessageBox.Show(
                        $"文件\"{FileName}\"复制失败\n" +
                        $"详细原因：\n" +
                        $"{Exp.Message}", "Serein",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning
                        );
                }
            }
        }
        public static void Remove(ListView.SelectedListViewItemCollection Items)
        {
            if (Items.Count == 1 && !Check())
            {
                if ((int)MessageBox.Show(
                    $"确定删除\"{Items[0].Text}\"？\n" +
                    $"它将会永远失去！（真的很久！）", "Serein",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                    ) == 1
                    && !Check())
                {
                    try
                    {
                        if (Items[0].ForeColor == Color.Gray)
                        {
                            File.Delete(PluginPath + "\\" + Items[0].Text + ".lock");
                        }
                        else
                        {
                            File.Delete(PluginPath + "\\" + Items[0].Text);
                        }
                    }
                    catch (Exception Exp)
                    {
                        MessageBox.Show(
                                $"文件\"{Items[0].Text}\"删除失败\n" +
                                $"详细原因：\n" +
                                $"{Exp.Message}", "Serein",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning
                                );
                    }
                }
            }
            else if (Items.Count > 1 && !Check())
            {
                if ((int)MessageBox.Show(
                   $"确定删除\"{Items[0].Text}\"等{Items.Count}个文件？\n" +
                   $"它将会永远失去！（真的很久！）", "Serein",
                   MessageBoxButtons.OKCancel, MessageBoxIcon.Information
                   ) == 1
                   && !Check())
                {
                    foreach (ListViewItem Item in Items)
                    {
                        try
                        {
                            if (Item.ForeColor == Color.Gray)
                            {
                                File.Delete(PluginPath + "\\" + Item.Text + ".lock");

                            }
                            else
                            {
                                File.Delete(PluginPath + "\\" + Item.Text);
                            }
                        }
                        catch (Exception Exp)
                        {
                            MessageBox.Show(
                                    $"文件\"{Item.Text}\"删除失败\n" +
                                    $"详细原因：\n" +
                                    $"{Exp.Message}", "Serein",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                                    );
                        }
                    }
                }

            }
        }
        public static void Disable(ListView.SelectedListViewItemCollection Items)
        {
            if (!Check())
            {
                foreach (ListViewItem Item in Items)
                {
                    try
                    {
                        FileInfo RenamedFile = new FileInfo(PluginPath + "\\" + Item.Text);
                        RenamedFile.MoveTo(PluginPath + "\\" + Item.Text + ".lock");
                    }
                    catch (Exception Exp)
                    {
                        MessageBox.Show(
                            $"文件\"{Item.Text}\"禁用失败\n" +
                            $"详细原因：\n" +
                            $"{Exp.Message}", "Serein",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning
                            );
                    }
                }
            }
        }
        public static void Enable(ListView.SelectedListViewItemCollection Items)
        {
            foreach (ListViewItem Item in Items)
            {
                try
                {
                    FileInfo RenamedFile = new FileInfo(PluginPath + "\\" + Item.Text + ".lock");
                    RenamedFile.MoveTo(PluginPath + "\\" + Item.Text);
                }
                catch (Exception Exp)
                {
                    MessageBox.Show(
                                    $"文件\"{Item.Text}\"禁用失败\n" +
                                    $"详细原因：\n" +
                                    $"{Exp.Message}", "Serein",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning
                                    );
                }
            }
        }
        public static bool Check()
        {
            if (Server.Status)
            {
                MessageBox.Show("服务器仍在运行中", "Serein", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
