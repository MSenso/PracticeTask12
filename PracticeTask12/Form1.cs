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
        void Pyramid_Sort(ref int[] array, ref int reference_count, ref int compare_count) // Пирамидальная сортировка
        {
            if (array.Length > 1) // Длина массива больше 1
            {
                for (int i = array.Length / 2 - 1; i >= 0; i--)
                    Make_Binary_Heap(ref array, array.Length, i, ref reference_count, ref compare_count); // Построение пирамиды, начиная с элемента с номером array.Length / 2 - 1
                for (int i = array.Length - 1; i >= 0; i--) // Сортировка пирамиды с конца
                {
                    if (0 != i) reference_count++; // Пересылка не одного и того же элемента
                    // Перестановка первого и последнего доступного элементов
                    int temp = array[0];
                    array[0] = array[i];
                    array[i] = temp;
                    Make_Binary_Heap(ref array, i, 0, ref reference_count, ref compare_count); // Построение пирамиды из доступной части массива
                }
            }
        }
        void Make_Binary_Heap(ref int[] array, int size, int index, ref int reference_count, ref int compare_count) // Построение пирамиды
        {
            int max_value_index = index;
            if (2 * index + 1 < size && array[2 * index + 1] > array[max_value_index]) // Если у элемента текущего элемента есть левый потомок и он больше максимального элемента в ветке
            {
                max_value_index = 2 * index + 1; // Теперь левый потомок является максимальным в ветви
                compare_count++; // Произошло сравнение
            }
            if (2 * index + 2 < size && array[2 * index + 2] > array[max_value_index]) // Если у элемента текущего элемента есть правый потомок и он больше максимального элемента в ветке
            {
                max_value_index = 2 * index + 2; // Теперь правый потомок является максимальным в ветви
                compare_count++; // Произошло сравнение
            }
            if (max_value_index != index) // Текущий элемент не является максимальным в ветке
            {
                // Перестановка текущего и максимального элементов
                int temp = array[index];
                array[index] = array[max_value_index];
                array[max_value_index] = temp;
                reference_count++; // Произошла пересылка
                Make_Binary_Heap(ref array, size, max_value_index, ref reference_count, ref compare_count); // Построение пирамиды относительно нового максимального элемента
            }
        }
        void Bucket_Sort(ref int[] array, ref int reference_count, ref int compare_count) // Блочная сортировка
        {
            if (array.Length > 1) // Длина массива больше 1
            {
                int max_elem = array[0];
                int min_elem = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] > max_elem) // Текущий элемент больше максимального
                        max_elem = array[i]; // Текущий элемент становится максимальным

                    else if (array[i] < min_elem) // Текущий элемент меньше минимального
                        min_elem = array[i]; // Текущий элемент становится минимальным
                }
                int buckets_count = (int)(Math.Ceiling((double)(max_elem - min_elem) / 10)) + 1; // Количество блоков равно разнице в десятках минимального и максимального элемента, округленного к большему, и увеличенной на 1
                List<int>[] buckets = new List<int>[buckets_count];
                int min_index = min_elem / 10; // Количество десятков минимального элемента, нужно для смещения в случае, если есть отрицательные элементы
                for (int i = 0; i < array.Length; i++)
                {
                    if (buckets[array[i] / 10 - min_index] == null) // Нет списка с индексом, равным разности количества десятков текущего и минимального элементов
                        buckets[array[i] / 10 - min_index] = new List<int>();
                    buckets[array[i] / 10 - min_index].Add(array[i]); // Добавление элемента в соответствующий блок
                }
                for (int i = 0; i < buckets_count; i++)
                {
                    if (buckets[i] != null) // Если список с таким индексом создан
                    {
                        if (buckets[i].Count > 1) // В списке больше 1 элемента, нужно сортировать
                        {
                            Insertion_Sort(ref buckets[i], ref compare_count); // Сортировка вставками
                        }
                    }
                }
                int index = 0;
                for (int i = 0; i < buckets_count; i++) // Поочередный перенос элементов из блоков в массив
                {
                    if (buckets[i] != null) // Если список с таким индексом создан
                    {
                        for (int j = 0; j < buckets[i].Count; j++)
                        {
                            if (!object.Equals(buckets[i][j], array[index])) // Если текущий элемент массива и блока не один и тот же
                                reference_count++; // Произошла пересылка
                            array[index] = buckets[i][j];
                            index++;
                        }
                    }
                }
            }
        }
        void Insertion_Sort(ref List<int> array, ref int compare_count) // Сортировка вставками
        {
            for (int i = 1; i < array.Count; i++)
            {
                int current_point = array[i]; // Текущий элемент
                int point_index = i - 1; // Индекс текущего элемента
                while (point_index >= 0 && array[point_index] > current_point) // Пока индекс неотрицательный и предыдущий элемент больше текущего
                {
                    compare_count++; // Произошло сравнение
                    array[point_index + 1] = array[point_index]; // Элемент с индексом point_index перемещается впмеред
                    point_index = point_index - 1; // Передвижение назад по массиву
                }
                if (point_index >= 0) compare_count++; // Произошло сравнение без захода в цикл
                array[point_index + 1] = current_point; // Вставить значение текущего элемента
            }
        }

        private void создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Counts(); // Очистка подсчетов
            Make_Sorts(1); // Сортировка отсортированного возрастающего массива
        }

        private void создатьОтсортированныйПоУбываниюМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Counts(); // Очистка подсчетов
            Make_Sorts(2); // Сортировка отсортированного убывающего массива
        }
        void Remove_Counts() // Удаление подсчетов
        {
            if (pyramid_reference != null) // Еще не удалено
            {
                Controls.Remove(pyramid_reference); // Удаление
                pyramid_reference = null;
            }
            if (pyramid_comparison != null) // Еще не удалено
            {
                Controls.Remove(pyramid_comparison); // Удаление
                pyramid_comparison = null;
            }
            if (bucket_reference != null) // Еще не удалено
            {
                Controls.Remove(bucket_reference); // Удаление
                bucket_reference = null;
            }
            if (bucket_comparison != null) // Еще не удалено
            {
                Controls.Remove(bucket_comparison); // Удаление
                bucket_comparison = null;
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void создатьНеотсортированныйМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog(); // Форма для ввода размера массива
            if (size > 0)
            {
                Remove_Counts(); // Очистка подсчетов
                Make_Arrays(); // Создание массивов
                Make_Sorts(0); // Сортировка неотсортированного массива
                // Доступны другие пункты меню
                создатьОтсортированныйПоВозрастаниюМассивToolStripMenuItem.Enabled = true;
                создатьОтсортированныйПоУбываниюМассивToolStripMenuItem.Enabled = true;
            }
        }

        public void Make_Arrays() // Создание массивов
        {
            pyramid_array = new int[size];
            bucket_array = new int[size];
            Random random = new Random();
            for (int i = 0; i < pyramid_array.Length; i++)
            {
                int new_element = random.Next(-100, 101); // Заполнение случайными числами от -100 до 100
                pyramid_array[i] = new_element; // Добавление элемента в массив для пирамидальной сортировки
                bucket_array[i] = new_element; // Добавление элемента в массив для блочной сортировки
            }
        }
        public void Make_Sorts(int order_case) // Отсортировать
        {
            if (order_case != 0) // Массив отсортирован
            {
                Array.Sort(pyramid_array); // Сортировка пирамидального массива
                Array.Sort(bucket_array); // Сортировка блочного массива
                if (order_case == 2) // Сортировка по убывания
                {
                    // Переворачивание массива позволяет получить отсортированные по убыванию массивы
                    Array.Reverse(pyramid_array);
                    Array.Reverse(bucket_array);
                }
            }
            if (Array_Label.Visible == false) Array_Label.Visible = true;
            else Array_Label.Text = "Исходный массив:";
            Print_Array(pyramid_array, ref Array_Label); // Вывод массива
            Pyramid_Sort(ref pyramid_array, ref pyramid_reference_count, ref pyramid_comparison_count); // Пирамидальная сортировка
            Print_Pyramid_Array(); // Вывод пирамидального массива
            Bucket_Sort(ref bucket_array, ref bucket_reference_count, ref bucket_comparison_count); // Блочная сортировка
            Print_Bucket_Array(); // Вывод блочного массива
        }
        void Print_Counts(int array_case) // Вывод подсчетов
        {
            switch (array_case)
            {
                case 0: // Пирамидальный массив
                    {
                        pyramid_reference = new Label() // Метка для вывода пересылок
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
                        pyramid_comparison = new Label() // Метка для вывода сравнений
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
                case 1: // Блочный массив
                    {
                        bucket_reference = new Label() // Метка для вывода пересылок
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
                        bucket_comparison = new Label() // Метка для вывода сравнений
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
        void Print_Array(int[] array, ref Label array_output) // Печать массива
        {
            for (int i = 0; i < array.Length; i++)
            {
                array_output.Text += " " + array[i].ToString();
            }
        }
        void Print_Pyramid_Array() // Печать пирамидального массива
        {
            if (pyramid_array_label == null)
            {
                pyramid_array_label = new Label() // Метка для вывода пирамидального массива
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
            Print_Array(pyramid_array, ref pyramid_array_label); // Печать массива
            Print_Counts(array_case: 0); // Печать подсчетов
        }
        void Print_Bucket_Array() // Печать блочного массива
        {
            if (bucket_array_label == null)
            {
                bucket_array_label = new Label() // Метка для вывода блочного массива
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
            Print_Array(bucket_array, ref bucket_array_label); // Печать массива
            Print_Counts(array_case: 1); // Печать подсчетов
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
