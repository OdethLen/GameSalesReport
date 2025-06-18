using Microsoft.VisualBasic.FileIO;

namespace GameSalesReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open csv file";
            openFileDialog.Filter = "csv files |*.csv";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            string filePath = openFileDialog.FileName;

            using (TextFieldParser textFieldParser = new TextFieldParser(filePath))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.Delimiters = new[] { "," };
                textFieldParser.HasFieldsEnclosedInQuotes = true;

                dgvData.Columns.Clear();
                dgvData.Rows.Clear();

                // Leer encabezados
                //Si todavia quedan lineas por leer
                if (!textFieldParser.EndOfData)
                {
                    foreach (var header in textFieldParser.ReadFields())
                        dgvData.Columns.Add(header, header);
                }

                // Leer filas
                //Mientas que queden lineas por leer seran agregadas
                while (!textFieldParser.EndOfData)
                    dgvData.Rows.Add(textFieldParser.ReadFields());
            }
        }

        private void formsPlotPie_Load(object sender, EventArgs e)
        {

        }

        private void btnPie_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count == 0)
                return;

            // Columna donde están los géneros, índice 4
            int genreColumnIndex = 3;

            // Diccionario para contar ocurrencias por género
            var genreCounts = new Dictionary<string, int>();

            // Recorrer todas las filas (sin contar la nueva fila vacía)
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var genreObj = row.Cells[genreColumnIndex].Value;
                if (genreObj == null)
                    continue;

                string genre = genreObj.ToString();

                if (genreCounts.ContainsKey(genre))
                    genreCounts[genre]++;
                else
                    genreCounts[genre] = 1;
            }

            if (genreCounts.Count == 0)
                return;

            // Preparar datos para el gráfico
            double[] values = genreCounts.Values.Select(v => (double)v).ToArray();
            string[] labels = genreCounts.Keys.ToArray();

            // Limpiar gráficos previos
            formsPlotPie.Plot.Clear();

            // Agregar gráfico de pastel (pie)
            var pie = formsPlotPie.Plot.Add.Pie(values);
            pie.ExplodeFraction = 0.1;
            pie.SliceLabelDistance = 0.5;

            // Asignar etiquetas a las porciones y leyenda
            double total = values.Sum();
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].LabelFontSize = 14;
                pie.Slices[i].Label = $"{labels[i]}: {pie.Slices[i].Value}";
                pie.Slices[i].LegendText = $"{labels[i]} ({pie.Slices[i].Value / total:p1})";
            }

            // Ajustes de apariencia
            formsPlotPie.Plot.Axes.Frameless();
            formsPlotPie.Plot.HideGrid();

            // Refrescar el control para mostrar el gráfico
            formsPlotPie.Refresh();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
