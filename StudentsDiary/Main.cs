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
        private FileHelper<List<Student>> _fileHelper = new FileHelper<List<Student>>(Program.path);

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
            if (IsMaximized)
                WindowState = FormWindowState.Maximized;
        }

        public void RefreshDiary()
        {
            var students = _fileHelper.DeserializerFromFile();
            students = students.OrderBy(x => x.Id).ToList();
            dgvDiary.DataSource = students;
        }
        private void SetColumnsHeaders()
        {
            dgvDiary.Columns[0].HeaderText = "Id";
            dgvDiary.Columns[1].HeaderText = "Imie";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Matematyka";
            dgvDiary.Columns[4].HeaderText = "J. Polski";
            dgvDiary.Columns[5].HeaderText = "J. Angielski";
            dgvDiary.Columns[6].HeaderText = "Uwagi";
            dgvDiary.Columns[7].HeaderText = "Dodatkowe zajęcia:";
            dgvDiary.Columns[8].HeaderText = "Id grupy";
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
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                IsMaximized = true;
            else
                IsMaximized = false;
            Settings.Default.Save();
        }

        private void RefreshStudents()
        {
            var students = _fileHelper.DeserializerFromFile();
            if (cmbSelectGroup.SelectedIndex == 0)
            {
                students = students.OrderBy(x => x.Id).ToList();
                dgvDiary.DataSource = students;
            }
            else if (cmbSelectGroup.SelectedIndex == 1)
            {
                students = students.FindAll(x => x.IdGroup == "Grupa A");
                dgvDiary.DataSource = students;
            }
            else if (cmbSelectGroup.SelectedIndex == 2)
            {
                students = students.FindAll(x => x.IdGroup == "Grupa B");
                dgvDiary.DataSource = students;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshStudents();
        }
    }
}
