using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Panhandler.Objects;

namespace Panhandler.UserTab
{
    public partial class UserContainer : UserControl
    {
        public UserContainer()
        {
            InitializeComponent();

            userListbox.Text = "";
            userListbox.SelectedIndexChanged += memberListbox_SelectedIndexChanged;
        }

        private void SortPlayers()
        {
            var userItems = userListbox.Items.Cast<string>();
            var sortedUsers = userItems
                                .Select(x => new User(x).userName)
                                .ToList();

            sortedUsers.Sort();

            var sortedList = sortedUsers
                                .Select(x => new User(userItems
                                                        .Where(y => y.Contains(x))
                                                        .FirstOrDefault().Trim()))
                                .Select(x => x.ToString())
                                .ToArray();

            userListbox.Items.Clear();
            userListbox.Items.AddRange(sortedList);
        }

        private async void addPerson_Click(object sender, EventArgs e)
        {

        }

        private async void updatePerson_Click(object sender, EventArgs e)
        {

        }

        private async void removePerson_Click(object sender, EventArgs e)
        {

        }
        
        protected void memberListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userListbox.SelectedItem == null || userListbox.SelectedIndex < 0) return;

            var currentUser = new User(userListbox.SelectedItem.ToString());

            userNameBox.Text = currentUser.userName;
            playerMultiplierBox.Text = currentUser.multiplier.ToString();
            userCodeBox.Text = currentUser.userId;
        }

        private void LoadUserStringIntoList(string userList)
        {
            userListbox.Items.Clear();

            foreach (var user in userList.Split(new char[] { '\n' }))
            {
                var currentUser = new User(user);
                var player = String.Format("{0,-35}|{1,-5}|{2}", new string[]{
                    currentUser.userName, currentUser.multiplier.ToString(), currentUser.userId
                });
                userListbox.Items.Add(player);
            }

            SortPlayers();
        }
    }
}
