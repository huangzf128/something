using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncFolder
{
    class NodeSupport
    {

        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        /// <summary>
        /// RootNodeを追加する
        /// </summary>
        /// <param name="fileNameList"></param>
        /// <param name="tree"></param>
        static public void addRootNode(List<string[]> fileNameList, TreeView tree)
        {
            foreach (string[] fileName in fileNameList)
            {
                string filename = fileName[0];
                TreeNode treeNode = new TreeNode(filename);
                treeNode.Name = filename;
                NodeSupport.setNodeColor(treeNode, 0);
                tree.Nodes.Add(treeNode);
                if (fileName[1] == "0")
                {
                    HideCheckBox(tree, treeNode);
                }
            }
        }

        /// <summary>
        //  SubNodeを追加する
        /// </summary>
        /// <param name="subFileNameList"></param>
        /// <param name="parentNode"></param>
        static public void addSubNode(List<string[]> subFileNameList, TreeNode parentNode, TreeView tv = null)
        {
            if (subFileNameList.Count <= 0) return;
            string parentName = getParentNodeLevel(parentNode);

            List<TreeNode> nodeList = new List<TreeNode>();
            for (int i = 0; i < subFileNameList.Count; i++)
            {
                string[] fileName = subFileNameList[i];
                TreeNode node = new TreeNode(fileName[0]);
                setNodeColor(node, Int32.Parse(fileName[1]));
                node.Name = parentName  + "_" + fileName[0];
                nodeList.Add(node);
            }

            TreeNode[] treeNodeSubFolder = nodeList.ToArray();
            parentNode.Nodes.AddRange(treeNodeSubFolder);

            if(tv != null)
            {
                // hide folder checkbox
                for (int i = 0; i < subFileNameList.Count; i++)
                {
                    if (subFileNameList[i][1] == "0")
                    {
                        HideCheckBox(tv, nodeList[i]);
                    }
                }
            }

            parentNode.Expand();
        }

        static public string getParentNodeLevel(TreeNode parentNode)
        {
            string name = parentNode.Name;
            return name;
        }

        static public string getNodePath(TreeNode node)
        {
            string nodePath = "";
            List<string> fList = new List<string>();
            do
            {
                fList.Add(node.Text);
                node = node.Parent;
            } while (node != null);

            for (int i = fList.Count - 1; i >= 0; i--)
            {
                nodePath += fList[i] + "\\";
            }

            return nodePath;
        }


        static public List<TreeNode>  getCheckedNode(System.Windows.Forms.TreeNodeCollection theNodes)
        {
            List<TreeNode> aResult = new List<TreeNode>();

            if (theNodes != null)
            {
                foreach (System.Windows.Forms.TreeNode aNode in theNodes)
                {
                    if (aNode.Checked)
                    {
                        aResult.Add(aNode);
                    }

                    aResult.AddRange(getCheckedNode(aNode.Nodes));
                }
            }

            return aResult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="kind">0:folder; 1:file</param>
        private static void setNodeColor(TreeNode node, int kind)
        {
            if (kind == 0)
            {
                // folder
                node.BackColor = Color.PapayaWhip;

            } else
            {
                // file
                //node.BackColor = Color.Moccasin;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        static private void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }

    }
}
