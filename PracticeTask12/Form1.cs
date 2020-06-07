using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeTask12
{
    public partial class Form1 : Form
    {
        Label pyramid_array_label, bucket_array_label, pyramid_reference, pyramid_comparison, bucket_reference, bucket_comparison;
        int[] pyramid_array, bucket_array;
        int pyramid_reference_count = 0, pyramid_comparison_count = 0, bucket_reference_count = 0, bucket_comparison_count = 0;
        public static int size;
        public Form1()
        {
            InitializeComponent();
        }
        void Pyramid_Sort(ref int[] array, ref int reference_count, ref int compare_count)
        {
            if (array.Length > 1)
            {
                for (int i = array.Length / 2 - 1; i >= 0; i--)
                    Make_Binary_Heap(ref array, array.Length, i, ref reference_count, ref compare_count);
                for (int i = array.Length - 1; i >= 0; i--)
                {

                    if (!object.ReferenceEquals(array[0], array[i])) reference_count++;
                    int temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;
                    Make_Binary_Heap(ref array, i, 0, ref reference_count, ref compare_count);
                }
            }
        }
        void Make_Binary_Heap(ref int[] array, int size, int index, ref int reference_count, ref int compare_count)
        {
            int max_value_index = index;
            if (2 * index + 1 < size && array[2 * index + 1] > array[max_value_index])
                max_value_index = 2 * index + 1;
            compare_count++;
            if (2 * index + 2 < size && array[2 * index + 2] > array[max_value_index])
                max_value_index = 2 * index + 2;
            compare_count++;
            if (max_value_index != index)
            {
                int temp = array[index];
                array[index] = array[max_value_index];
                array[max_value_index] = temp;
                reference_count++;
                Make_Binary_Heap(ref array, size, max_value_index, ref reference_count, ref compare_count);
            }
        }
        void Bucket_Sort(ref int[] array, ref int reference_count, ref int compare_count)
        {
            if (array.Length > 1)
            {
                int max_elem = array[0];
                int min_elem = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max_elem)
                        max_elem = array[i];

                    else if (array[i] < min_elem)
                        min_elem = array[i];
                    compare_count += 2;
                }
                int buckets_count = (int)(Math.Ceiling((double)(max_elem - min_elem) / 10)) + 1;
                List<int>[] buckets = new List<int>[buckets_count];
                int min_index = min_elem / 10;
                for (int i = 0; i < array.Length; i++)
                {
                    if (buckets[array[i] / 10 - min_index] == null)
                        buckets[array[i] / 10 - min_index] = new List<int>();
                    buckets[array[i] / 10 - min_index].Add(array[i]);
                }
                for (int i = 0; i < buckets_count; i++)
                {
                    if (buckets[i] != null)
                    {
                        if (buckets[i].Count > 1)
                        {
                            Insertion_Sort(ref buckets[i], ref reference_count, ref compare_count);
                        }
                    }
                }
                int index = 0;
                for (int i = 0; i < buckets_count; i++)
                {
                    if (buckets[i] != null)
                    {
                        for (int j = 0; j < buckets[i].Count; j++)
                        {
                            if (!object.ReferenceEquals(buckets[i][j], array[index])) reference_count++;
                            array[index] = buckets[i][j];
                            index++;
                        }
                    }
                }
            }
        }
        void Insertion_Sort(ref List<int> array, ref int reference_count, ref int compare_count)
        {
            for (int i = 1; i < array.Count; i++)
            {
                int current_point = array[i];
                int point_index = i - 1;
                while (point_index >= 0 && array[point_index] > current_point)
                {
                    compare_count++;
                    array[point_index + 1] = array[point_index];
                    reference_count++;
                    point_index = point_index - 1;
                }
                compare_count++;
                if (!object.ReferenceEquals(array[point_index + 1], array[i])) reference_count++;
                array[point_index + 1] = current_point;
            }
        }

        private void создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Counts();
            Make_Sorts(1);
        }

        private void создатьОтсортированныйПоУбываниюМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Counts();
            Make_Sorts(2);
        }

        void Show(int[] array)
        {
            string res = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        void Remove_Counts()
        {
            if (pyramid_reference != null)
            {
                Controls.Remove(pyramid_reference);
                pyramid_reference = null;
            }
            if (pyramid_comparison != null)
            {
                Controls.Remove(pyramid_comparison);
                pyramid_comparison = null;
            }
            if (bucket_reference != null)
            {
                Controls.Remove(bucket_reference);
                bucket_reference = null;
            }
            if (bucket_comparison != null)
            {
                Controls.Remove(bucket_comparison);
                bucket_comparison = null;
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void создатьНеотсортированныйМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (size > 0)
            {
                Remove_Counts();
                Make_Arrays();
                Make_Sorts(0);
                создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Enabled = true;
                создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Enabled = true;
            }
        }

        void Make_Arrays()
        {
            pyramid_array = new int[size];
            bucket_array = new int[size];
            Random random = new Random();
            for (int i = 0; i < pyramid_array.Length; i++)
            {
                int new_element = random.Next(-100, 100);
                pyramid_array[i] = new_element;
                bucket_array[i] = new_element;
            }
        }
        void Make_Sorts(int order_case)
        {
            if (order_case != 0)
            {
                Array.Sort(pyramid_array);
                Array.Sort(bucket_array);
                if (order_case == 2)
                {
                    Array.Reverse(pyramid_array);
                    Array.Reverse(bucket_array);
                }
            }
            if (Array_Label.Visible == false) Array_Label.Visible = true;
            else Array_Label.Text = "Исходный массив:";
            Print_Array(pyramid_array, ref Array_Label);
            Pyramid_Sort(ref pyramid_array, ref pyramid_reference_count, ref pyramid_comparison_count);
            Print_Pyramid_Array();
            Bucket_Sort(ref bucket_array, ref bucket_reference_count, ref bucket_comparison_count);
            Print_Bucket_Array();
        }
        void Print_Counts(int array_case)
        {
            switch (array_case)
            {
                case 0:
                    {
                        pyramid_reference = new Label()
                        {
                            Name = "Pyramid_Reference",
                            AutoSize = true,
                            Text = "Количество пересылок: " + pyramid_reference_count.ToString(),
                            Font = Array_Label.Font,
                            BackColor = Color.Transparent,
                            ForeColor = Color.Black,
                            Location = new Point(pyramid_array_label.Location.X, pyramid_array_label.Location.Y + pyramid_array_label.Height + 20)
                        };
                        Controls.Add(pyramid_reference);
                        pyramid_reference_count = 0;
                        pyramid_comparison = new Label()
                        {
                            Name = "Pyramid_Comparison",
                            AutoSize = true,
                            Text = "Количество сравнений: " + pyramid_comparison_count.ToString(),
                            Font = Array_Label.Font,
                            BackColor = Color.Transparent,
                            ForeColor = Color.Black,
                            Location = new Point(pyramid_reference.Location.X, pyramid_reference.Location.Y + pyramid_reference.Height + 20)
                        };
                        Controls.Add(pyramid_comparison);
                        pyramid_comparison_count = 0;
                        break;
                    }
                case 1:
                    {
                        bucket_reference = new Label()
                        {
                            Name = "Bucket_Reference",
                            AutoSize = true,
                            Text = "Количество пересылок: " + bucket_reference_count.ToString(),
                            Font = Array_Label.Font,
                            BackColor = Color.Transparent,
                            ForeColor = Color.Black,
                            Location = new Point(bucket_array_label.Location.X, bucket_array_label.Location.Y + bucket_array_label.Height + 20)
                        };
                        Controls.Add(bucket_reference);
                        bucket_reference_count = 0;
                        bucket_comparison = new Label()
                        {
                            Name = "Bucket_Comparison",
                            AutoSize = true,
                            Text = "Количество сравнений: " + bucket_comparison_count.ToString(),
                            Font = Array_Label.Font,
                            BackColor = Color.Transparent,
                            ForeColor = Color.Black,
                            Location = new Point(bucket_reference.Location.X, bucket_reference.Location.Y + bucket_reference.Height + 20)
                        };
                        Controls.Add(bucket_comparison);
                        bucket_comparison_count = 0;
                        break;
                    }
            }
        }
        void Print_Array(int[] array, ref Label array_output)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array_output.Text += " " + array[i].ToString();
            }
        }
        void Print_Pyramid_Array()
        {
            if (pyramid_array_label == null)
            {
                pyramid_array_label = new Label()
                {
                    Name = "Pyramid_Array_Label",
                    Text = "Пирамидальная сортировка:",
                    AutoSize = true,
                    Location = new Point(Array_Label.Location.X, Array_Label.Location.Y + Array_Label.Height + 20),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    Font = Array_Label.Font
                };
                Controls.Add(pyramid_array_label);
            }
            else pyramid_array_label.Text = "Пирамидальная сортировка:";
            Print_Array(pyramid_array, ref pyramid_array_label);
            Print_Counts(array_case: 0);
        }
        void Print_Bucket_Array()
        {
            if (bucket_array_label == null)
            {
                bucket_array_label = new Label()
                {
                    Name = "Bucket_Array_Label",
                    Text = "Блочная сортировка:",
                    AutoSize = true,
                    Location = new Point(pyramid_comparison.Location.X, pyramid_comparison.Location.Y + pyramid_comparison.Height + 20),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black,
                    Font = Array_Label.Font
                };
                Controls.Add(bucket_array_label);
            }
            else bucket_array_label.Text = "Блочная сортировка:";
            Print_Array(bucket_array, ref bucket_array_label);
            Print_Counts(array_case: 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Make_Arrays();
        }
    }
}
