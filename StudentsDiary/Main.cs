using StudentsDiary.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class Main : Form
    {
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.path,Program.xmlJsonChangerB);
        private List<Group> _groups;

        public bool IsMaximized
        {
            get
            {
                return Settings.Default.IsMaximized;
            }
            set
            {
                Settings.Default.IsMaximized = value;
            }
        }

        public Main()
        {
            InitializeComponent();
            RefreshDiary();

            SetColumnsHeaders();

            _groups = GroupsHelper.GetGroups("Wszyscy");
            InitGroupsComboBox();

            if (IsMaximized)
                WindowState = FormWindowState.Maximized;
        }

        private void InitGroupsComboBox()
        {
            cmbGroup.DataSource = _groups;
            cmbGroup.DisplayMember = "GroupName";
            cmbGroup.ValueMember = "Id";
        }

        public void RefreshDiary()
        {
            var students = _fileHelper.DeserializerFromFile();
            students = students.OrderBy(x => x.Id).ToList();
            dgvDiary.DataSource = students;
        }
        private void SetColumnsHeaders()
        {
            //dgvDiary.Columns[nameof(Student.Comments)].DisplayIndex = 1;
            dgvDiary.Columns[nameof(Student.Id)].HeaderText = "Id";
            dgvDiary.Columns[nameof(Student.Name)].HeaderText = "Imie";
            dgvDiary.Columns[nameof(Student.Surname)].HeaderText = "Nazwisko";
            dgvDiary.Columns[nameof(Student.Math)].HeaderText = "Matematyka";
            dgvDiary.Columns[nameof(Student.LangPolish)].HeaderText = "J. Polski";
            dgvDiary.Columns[nameof(Student.LangEnglish)].HeaderText = "J. Angielski";
            dgvDiary.Columns[nameof(Student.Comments)].HeaderText = "Uwagi";
            dgvDiary.Columns[nameof(Student.AdditionalLesson)].HeaderText = "Dodatkowe zajęcia:";
            dgvDiary.Columns[nameof(Student.IdGroup)].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void AddEditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshDiary();
            RefreshStudentsGroups();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden uczeń nie został wybrany.");
                return;
            }
            var addEditStudent = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Żaden uczeń nie został wybrany.");
                return;
            }
            var selectedStudent = dgvDiary.SelectedRows[0];
            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia {selectedStudent.Cells[1].Value.ToString().Trim()} " +
                $"{selectedStudent.Cells[2].Value.ToString().Trim()}?", "Usuwanie ucznia", MessageBoxButtons.OKCancel);
            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
            }
        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelper.DeserializerFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelper.SerializeToFile(students);
            RefreshDiary();
            RefreshStudentsGroups();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                IsMaximized = true;
            else
                IsMaximized = false;
            Settings.Default.Save();
        }

        private void RefreshStudentsGroups()
        {
            var students = _fileHelper.DeserializerFromFile();
            var selectedItem = (cmbGroup.SelectedItem as Group).Id;

            if ( selectedItem == 0)
                students = students.OrderBy(x => x.Id).ToList();
            else
                students = students.FindAll(x => x.IdGroup == selectedItem);

            dgvDiary.DataSource = students;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshStudentsGroups();
        }
        
        private void ckbJSON_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbJSON.Checked)
                Program.xmlJsonChangerB = true;
            else
                Program.xmlJsonChangerB = false;
            _fileHelper = new FileHelper<List<Student>>(Program.path, Program.xmlJsonChangerB);
            RefreshDiary();
            RefreshStudentsGroups();
        }

        private void btnSerializeToDifferentDataBase_Click(object sender, EventArgs e)
        {
            var students = _fileHelper.DeserializerFromFile();
            _fileHelper.SerializeToSecondDataBase(students);
        }
    }
}
