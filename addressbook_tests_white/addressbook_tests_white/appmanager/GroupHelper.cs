using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;






namespace addressbook_tests_white
{
    public class GroupHelper: HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
           
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                }
                   );
            }
           
            CloseGroupsDialog(dialogue);
            return list;

        }

        public void CloseGroupsDialog(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);

        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialog();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textbox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textbox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN); //simulate ENTER

            CloseGroupsDialog(dialogue);

        }

        

        public void Remove(GroupData groupToRemove)
        {
            string groupName = groupToRemove.Name;
            Window dialogue = OpenGroupsDialog();
           

            TreeNode tree = dialogue.Get<TreeNode>(SearchCriteria.ByText(groupName));
            tree.Select();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            Window deleteWindow = dialogue.ModalWindow(DELETEGROUPWINTITLE);
            deleteWindow.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialogue);

        }

        /*
        public GroupData GetGroupForRemove()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                }
                   );
            }

            GroupData group = list[0];
            CloseGroupsDialog(dialogue);

            return group;
        
        }
        */
    }
}