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

        private void btnTreeView_Click(object sender, EventArgs e)
        {

            treeViewData.Nodes.Clear();

            // Índices de columnas relevantes
            int idxName = 0;
            int idxPlatform = 1;
            int idxYear = 2;
            int idxGenre = 3;
            int idxPublisher = 4;

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string publisher = row.Cells[idxPublisher].Value?.ToString() ?? "Unknown Publisher";
                string genre = row.Cells[idxGenre].Value?.ToString() ?? "Unknown Genre";
                string platform = row.Cells[idxPlatform].Value?.ToString() ?? "Unknown Platform";
                string year = row.Cells[idxYear].Value?.ToString() ?? "Unknown Year";
                string gameName = row.Cells[idxName].Value?.ToString() ?? "Unknown Game";

                // Nivel 1: Publisher
                TreeNode publisherNode = treeViewData.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text == publisher) ?? treeViewData.Nodes.Add(publisher);

                // Nivel 2: Genre
                TreeNode genreNode = publisherNode.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text == genre) ?? publisherNode.Nodes.Add(genre);

                // Nivel 3: Platform
                TreeNode platformNode = genreNode.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text == platform) ?? genreNode.Nodes.Add(platform);

                // Nivel 4: Year
                TreeNode yearNode = platformNode.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text == year) ?? platformNode.Nodes.Add(year);

                // Nivel 5: Game Name
                yearNode.Nodes.Add(gameName);
            }

            treeViewData.ExpandAll(); // Opcional: para mostrarlo expandido desde el inic
            MessageBox.Show("¡TreeView generado correctamente!");
        }

        private void treeViewData_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
