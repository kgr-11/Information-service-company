using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using Mysqlx.Crud;
using System.Management;
using MySqlX.XDevAPI.Common;
using Mysqlx.Session;

namespace DB2
{
	public partial class Form1 : Form
	{
		BasicQuery query;
		string connectioinString = "server=localhost;port=3306;user=root;password=password";

		private void updateDataGridViewStorage()
		{
			dataGridView_storage.DataSource = null;
			dataGridView_storage.Rows.Clear();
			dataGridView_storage.Columns.Clear();

			MySqlConnection conn=new MySqlConnection(connectioinString);
			MySqlCommand cmd=new MySqlCommand(query.selectDataAboutParties, conn);  
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
			DataTable dataTable = new DataTable();
			adapter.Fill(dataTable);
			dataGridView_storage.DataSource=dataTable;
		}
		private void updateDataGridViewPrice()
		{
			dataGridView_price.DataSource = null;
			dataGridView_price.Rows.Clear();
			dataGridView_price.Columns.Clear();

			MySqlConnection conn = new MySqlConnection(connectioinString);
			MySqlCommand cmd = new MySqlCommand(query.selectActualPrice, conn);
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
			DataTable dataTable = new DataTable();
			adapter.Fill(dataTable);
			dataGridView_price.DataSource = dataTable;
		}
		private void settingDataGridView()
		{
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView3.ReadOnly = true;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView4.ReadOnly = true;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

		private void updatedataGridView1AND2AND3()
		{
            //1. нужно достать все заказы
            MySqlConnection conn = new MySqlConnection(connectioinString);
            MySqlCommand cmd = new MySqlCommand("", conn);
            string selectOrderFromArchive = @"USE corparation;
												  SELECT content
												  FROM archive
												  WHERE type_doc='Накладная';";
            cmd.CommandText = selectOrderFromArchive;
            List<string> orders = new List<string>();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orders.Add(reader["content"].ToString());
            }
            conn.Close();
            reader.Close();
            //теперь их надо распаковать
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            decimal all_profit = 0;
            for (int k = 0; k < orders.Count(); k++)
            {
                //здесь распаковка
                //извлечение контента
                string[] rows = orders[k].Split('\n');//отделили строки
                for (int i = 0; i < rows.Length - 1; i++)
                {
                    string[] parts_row = rows[i].Split(';');
                    string[] result_row = new string[parts_row.Length];//0-Название продукта,1-количества,2-ед изм,3-цена продажи, 4-цена закупки
                    for (int j = 0; j < parts_row.Length; j++)
                    {
                        int index = parts_row[j].IndexOf(": ") + ": ".Length;
                        result_row[j] = parts_row[j].Substring(index);
                    }
                    //нужно проверить нет ли такого продукта в списке
                    if (!result.ContainsKey(result_row[0]))//добавляем новый товар в словарь
                    {
                        decimal profit = Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
                        all_profit += profit;
                        result.Add(result_row[0], profit);
                        counts.Add(result_row[0], 1);
                    }
                    else //если такой есть, обновляем прибыль с него
                    {
                        decimal profit = result[result_row[0]];
                        profit += Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
                        all_profit += profit;
                        result[result_row[0]] = profit;

						int col = counts[result_row[0]];
						col++;
                        counts[result_row[0]] = col;
                    }
                }
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Товар", typeof(string));
            dataTable.Columns.Add("Выручка по товару за все время", typeof(decimal));
			dataTable.Columns.Add("Количество раз заказывали", typeof(int));
			// Перебор всех пар ключ-значение
			int count = 0;
            foreach (KeyValuePair<string, decimal> item in result)
            {
				if (count == 10)
				{
					break;
				}
                DataRow row = dataTable.NewRow();
                row["Товар"] = item.Key;
                row["Выручка по товару за все время"] = item.Value;
				row["Количество раз заказывали"] = counts[item.Key];
                dataTable.Rows.Add(row);
				count++;
            }
            dataGridView1.DataSource = dataTable;
			DataTable dt3 = dataTable.Copy();
            dataGridView3.DataSource = dt3;

            // Сортировка по столбцу по возрастанию
            dataGridView3.Sort(dataGridView3.Columns["Выручка по товару за все время"], ListSortDirection.Ascending);
            dataGridView3.Columns["Количество раз заказывали"].Visible = false;
            // По убыванию
            dataGridView1.Sort(dataGridView1.Columns["Количество раз заказывали"], ListSortDirection.Descending);
			dataGridView1.Columns["Выручка по товару за все время"].Visible = false;
            DataTable dt2= dataTable.Copy();
            dataGridView2.DataSource = dt2;
            // Сортировка по столбцу по возрастанию
            dataGridView2.Sort(dataGridView2.Columns["Количество раз заказывали"], ListSortDirection.Ascending);
            dataGridView2.Columns["Выручка по товару за все время"].Visible = false;
        }
		private void updatedataGridView4()
		{
            //достаем всех клиентов, затем достаем их заказы, распаковываем каждый заказ и нахоходим по нему прибыль, суммируем, добавлем все это в словарь
            // клиент-прибыль с него
            MySqlConnection conn = new MySqlConnection(connectioinString);
            string selectProfitClient = @"USE corparation;
										  SELECT 
										  	clients.id,
										      CONCAT_WS(' ',physical_person.firstname,physical_person.secondname, physical_person.thirdname) AS client
										  FROM clients
										  INNER JOIN physical_person ON clients.id_physical_person=physical_person.id_person
										  UNION ALL
										  SELECT 
										  	clients.id,
										      legal_entity.name_company AS client
										  FROM clients
										  INNER JOIN legal_entity ON clients.id_legal_entity=legal_entity.id_company;";
            MySqlCommand cmd = new MySqlCommand(selectProfitClient, conn);
            conn.Open();
			MySqlDataReader reader = cmd.ExecuteReader();
			List<KeyValuePair<string,string>> clients = new List<KeyValuePair<string,string>>();
			while (reader.Read())
			{
				clients.Add(new KeyValuePair<string, string>(reader["id"].ToString(), reader["client"].ToString()));
			}
			reader.Close();
			conn.Close();
            Dictionary<string, decimal> client_with_profit = new Dictionary<string, decimal>();
			//перебор клиентов
            for (int k = 0; k < clients.Count(); k++)
            {
				//достаем все заказы k-клиента
				string selectOrderOfClient = @"USE corparation;
								             SELECT
											    cheque.content
											FROM cheque
											WHERE cheque.client_id=@id;";
				cmd.Parameters.Clear();
				cmd.CommandText= selectOrderOfClient;
				cmd.Parameters.AddWithValue("@id", clients[k].Key);
				List<string>contentOfClient = new List<string>();
				conn.Open();
				reader=cmd.ExecuteReader();
				while (reader.Read())
				{ 
					contentOfClient.Add(reader["content"].ToString());
				}
				conn.Close();
				reader.Close();
				//перебор заказов клиентов
				for (int j = 0; j < contentOfClient.Count(); j++)
				{
                    //здесь распаковка
                    //извлечение контента
                    string[] rows = contentOfClient[j].Split('\n');//отделили строки
                    for (int i = 0; i < rows.Length - 1; i++)
                    {
                        string[] parts_row = rows[i].Split(';');
                        string[] result_row = new string[parts_row.Length];//0-Название продукта,1-количества,2-ед изм,3-цена продажи, 4-цена закупки
                        for (int ii = 0; ii < parts_row.Length; ii++)
                        {
                            int index = parts_row[ii].IndexOf(": ") + ": ".Length;
                            result_row[ii] = parts_row[ii].Substring(index);
                        }
                        //нужно проверить нет ли такого продукта в списке
                        if (!client_with_profit.ContainsKey(clients[k].Value))//добавляем новый товар в словарь
                        {
                            decimal profit = Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
                            client_with_profit.Add(clients[k].Value, profit);
                        }
                        else //если такой есть, обновляем прибыль с него
                        {
                            decimal profit = client_with_profit[clients[k].Value];
                            profit += Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
                            client_with_profit[clients[k].Value] = profit;
                        }
                    }
                }
            }
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Клиент", typeof(string));
			dataTable.Columns.Add("Прибыль с клиента", typeof(decimal));
			foreach (string key in client_with_profit.Keys)
			{ 
				DataRow row = dataTable.NewRow();
				row["Клиент"] = key;
				row["Прибыль с клиента"]=client_with_profit[key];
				dataTable.Rows.Add(row);
			}
			dataGridView4.DataSource = dataTable;
            dataGridView4.Sort(dataGridView4.Columns["Прибыль с клиента"], ListSortDirection.Descending);
        }
		private void updateMarketDepartament()
		{
			updatedataGridView1AND2AND3();
			updatedataGridView4();
        }
		public Form1()
		{
			InitializeComponent();
			query = new BasicQuery();
			dataGridView_storage.ReadOnly = true;
			dataGridView_storage.AllowUserToAddRows = false;
			dataGridView_storage.AllowUserToDeleteRows = false;
			dataGridView_storage.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
			dataGridView_storage.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
			updateDataGridViewStorage();

			dataGridView_price.ReadOnly = true;
			dataGridView_price.AllowUserToAddRows = false;
			dataGridView_price.AllowUserToDeleteRows = false;
			dataGridView_price.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
			dataGridView_price.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
			updateDataGridViewPrice();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dataGridView_profit.ReadOnly = true;
            dataGridView_profit.AllowUserToAddRows = false;
            dataGridView_profit.AllowUserToDeleteRows = false;
            dataGridView_profit.DefaultCellStyle.Font = new Font("Times New Roman", 10);//стиль самих ячеек
            dataGridView_profit.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView_profit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			//настройка таблиц в отделе маркетинга
			settingDataGridView();
			updateMarketDepartament();

            //для отдела продаж
            dataGridView_cheque.AllowUserToAddRows = false;
            dataGridView_cheque.AllowUserToDeleteRows = false;
            dataGridView_cheque.ReadOnly = true;
            dataGridView_cheque.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView_cheque.DefaultCellStyle.Font = new Font("Timew New Roman", 10);
            dataGridView_cheque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            textBox_number_cheque.ReadOnly = true;
            updateCheque();
        }

		private void RegistrationProductToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn=new MySqlConnection(connectioinString);
			conn.Open();
			string selectSection = @"USE corparation;
									 SELECT DISTINCT name_section
									 FROM cells;";
			MySqlCommand cmd=new MySqlCommand(selectSection, conn);
			List<string> section = new List<string>();
			MySqlDataReader reader=cmd.ExecuteReader();
			while (reader.Read())
			{
				section.Add(reader["name_section"].ToString());
			}
			reader.Close();
			if (section.Count() == 0)
			{
				MessageBox.Show("На складе ещё нет зарегистрированных ячеек. Пока товар добавить нельзя. Добавьте ячейки.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				conn.Close();   
				return;
			}
			string countProducts = @"USE corparation;
									 SELECT COUNT(id_product)
									 FROM products;";
			cmd.Parameters.Clear();
			cmd.CommandText= countProducts;
			if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
			{
				MessageBox.Show("На складе ещё нет зарегистрированного товара. Пока партию принять нельзя. Добавьте товар.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				conn.Close();
				return;
			}
			string secectCells= @"USE corparation;
									 SELECT id_cell, name_section,number_cell
									 FROM cells
									 WHERE status_cell='свободно';";
			cmd.CommandText = secectCells;
			List<List<string>> cells = new List<List<string>>();
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				cells.Add(new List<string>() { reader["id_cell"].ToString(), reader["name_section"].ToString(), reader["number_cell"].ToString() });
			}
			reader.Close();
			//нужно закинуть на форму таблицу с продуктами и их id
			string selectProducts = @"USE corparation;
									  SELECT id_product,
											 name_product
									  FROM products;";
			cmd.CommandText = selectProducts;
			cmd.Parameters.Clear();
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
			DataTable products = new DataTable();
			adapter.Fill(products);
			conn.Close();
			RegistrationProduct reg =new RegistrationProduct(section, cells,products);
			DialogResult result = reg.ShowDialog();
			if (result == DialogResult.OK)
			{
				string id_product=reg.id_product;
				decimal productCount=reg.productCount;
				string unit_measure=reg.unit_measure;
				string delivery_date=reg.delivery_date;
				string expiration_date=reg.expiration_date;
				int temperature=reg.temperature;
				decimal purchase_price=reg.purchase_price;
				string id_cell=reg.id_cell;
				string number_partie=reg.number_partie;
				conn.Open();
				//добавляем продукт в систему склада
				cmd.CommandText = query.insertPartie;
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@count_product", productCount);
				cmd.Parameters.AddWithValue("@unit_of_measurement", unit_measure);
				cmd.Parameters.AddWithValue("@delivery_date", delivery_date);
				cmd.Parameters.AddWithValue("@storage_date", expiration_date);
				cmd.Parameters.AddWithValue("@temperature", temperature);
				cmd.Parameters.AddWithValue("@id_cell", id_cell);
				cmd.Parameters.AddWithValue("@purshase_price", purchase_price);
				cmd.Parameters.AddWithValue("@id_product", id_product);
				cmd.Parameters.AddWithValue("@number_partie", number_partie);
				try
				{
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex)when (ex.Number==1062)
				{
					MessageBox.Show("Партия с таким номером уже существует! Попробуйте еще раз!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					conn.Close();
					reg.Dispose();
					return;
				}
				//изменяем статус ячейки продукта на 'занято'
				cmd.CommandText = @"USE corparation;
									UPDATE cells
									SET status_cell='занято'
									WHERE id_cell=@id_cell;";
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@id_cell", id_cell);
				cmd.ExecuteNonQuery();
				conn.Close();
				updateDataGridViewStorage();
			}
			reg.Dispose();
		}

		private void AddSectionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn = new MySqlConnection(connectioinString);
			string selectSection = @"USE corparation;
								   SELECT DISTINCT name_section
								   FROM cells;";
			conn.Open();
			MySqlCommand cmd=new MySqlCommand(selectSection, conn);
			List<string> section = new List<string>();
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				section.Add(reader["name_section"].ToString());
			}
			conn.Close();
			Section form = new Section(section);
			DialogResult result=form.ShowDialog();
			if (result == DialogResult.OK)
			{
				string newSection = form.nameSection;
				int countCells=form.countCells;
				//составление запроса на добавление ячеек на склад
				string insertCells = @"USE corparation;
									   INSERT INTO cells(name_section,number_cell) VALUES
										";
				char symbol_cell = 'A';
				int number_cell = 1;
				for (int i = 1; i <= countCells; i++)
				{
					string val = "";
					if (i != countCells)
					{
						val = "(" +"'"+newSection+"'" + "," + "'"+symbol_cell.ToString() + number_cell.ToString()+"'" + ")"+",\n";
					}
					else 
					{
						val = "(" + "'" + newSection + "'" + "," + "'" + symbol_cell.ToString() + number_cell.ToString() + "'" + ");";
					}
					insertCells+= val;
					number_cell++;
					if (i % 10 == 0)
					{
						int s = Convert.ToInt32(symbol_cell);
						symbol_cell = Convert.ToChar(++s);
						number_cell = 1;
					}
				}
				conn.Open();
				cmd.CommandText = insertCells;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
			form.Dispose();
		}

		//назначение продажной стоимности
		private void SalePriceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn=new MySqlConnection(connectioinString);
			MySqlCommand cmd = new MySqlCommand("", conn);
			//проверка, что хоть что-нибудь есть на складе, чтобы можно было установить цену
			/*string chechStorage = @"USE corparation;
									SELECT COUNT(id_partie) AS counts
									FROM parties;";
			cmd.CommandText = chechStorage;
			conn.Open();
			int count=Convert.ToInt32(cmd.ExecuteScalar());
			if (count == 0)
			{
				MessageBox.Show("На складе нет товара. Склад полностью пустой.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				conn.Close();
				return;
				
			}*/
			//получаем таблицу id, название товара, средняя стомность,продажная цена если есть, иначе ""
			string selectPartie = @"USE corparation;
									SELECT SUM(count_product) counts,
										   SUM(purshase_price*count_product) price,
										   id_product
									FROM parties
									GROUP BY id_product;";
			cmd.CommandText= selectPartie;
			List<List<string>>list_product = new List<List<string>>();
			conn.Open();
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				list_product.Add(new List<string>() { reader["counts"].ToString(), reader["price"].ToString(), reader["id_product"].ToString() });
			}
			reader.Close();
			string selectProduct= @"USE corparation;
									SELECT id_product,
											name_product,
											CASE 
												WHEN sale_price IS NULL THEN ''
												ELSE sale_price
											END AS sale_price
									FROM products;";
			cmd.CommandText= selectProduct;
			List<List<string>> productName = new List<List<string>>();
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				productName.Add(new List<string>() { reader["id_product"].ToString(), reader["name_product"].ToString(), reader["sale_price"].ToString() });
			}
			conn.Close();
			//теперь надо составить таблицу DataTable
			DataTable dataProduct = new DataTable();
			dataProduct.Columns.Add("id", typeof(string));
			dataProduct.Columns.Add("product", typeof(string));
			dataProduct.Columns.Add("avg_price", typeof(string));
			dataProduct.Columns.Add("sale_price", typeof(string));
			for (int i = 0; i < productName.Count(); i++)
			{
				//расчет средней цены товара
				decimal avg_price = 0;
				for (int j = 0; j < list_product.Count(); j++)
				{
					if (list_product[j][2] == productName[i][0])
					{
						//расчет средней цены
						avg_price = Convert.ToDecimal(list_product[j][1]) / Convert.ToDecimal(list_product[j][0]);
						break;
					}
				}
				//добавление товара со средней ценой в таблицу
				dataProduct.Rows.Add(productName[i][0], productName[i][1], avg_price.ToString("F2"), productName[i][2]);

			}
			SalePrice form= new SalePrice(connectioinString, dataProduct);    
			DialogResult result= form.ShowDialog();
			if (result == DialogResult.OK)
			{
				decimal salePrice = form.sale_price;
				string id = form.id;
				//устанавливаем цену товару
				cmd.CommandText = query.updateSalePrice;
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@price", salePrice);
				cmd.Parameters.AddWithValue("@id", id);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
				updateDataGridViewPrice();
			}
			form.Dispose();
		}

		private void RegProductToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn=new MySqlConnection(connectioinString);
			string select_products = @"USE corparation;
									   SELECT name_product
									   FROM products;";
			MySqlCommand cmd= new MySqlCommand(select_products, conn);
			List<string> products = new List<string>();
			conn.Open();
			MySqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				products.Add(reader["name_product"].ToString());
			}
			conn.Close();
			ProductReg reg = new ProductReg(products);
			DialogResult result= reg.ShowDialog();
			if (result == DialogResult.OK)
			{
				string name = reg.name;
				string insertProduct = @"USE corparation;
										 INSERT INTO products(name_product)
										 VALUES (@name);";
				cmd.CommandText=insertProduct;
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@name", name);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();   
			}
			reg.Dispose();
		}

		private void getActToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//нужно получить все несписанные партии
			string selectActivePartie = @"USE corparation;
										  SELECT 
											parties.id_partie,
											parties.number_partie AS 'Номер партии',
											products.name_product AS 'Название продукта',
											parties.count_product 'Количество',
											parties.unit_of_measurement 'Единица измерения',
											parties.delivery_date 'Дата поступления',
											parties.storage_date AS 'Дата истечения срока хранения'
										  FROM parties
										  INNER JOIN products ON parties.id_product=products.id_product
										  LEFT JOIN  connectioin_product_and_documents ON connectioin_product_and_documents.id_partie=parties.id_partie  -- ЕСЛИ СВЯЗИ НЕТ БУДЕТ null
										  WHERE connectioin_product_and_documents.id_partie IS NULL; -- все партии, которые не списаны и не в накладных
										  ";
			MySqlConnection conn = new MySqlConnection(connectioinString);
			MySqlCommand cmd=new MySqlCommand(selectActivePartie, conn);
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
			DataTable parties= new DataTable();
			adapter.Fill(parties);
			conn.Close();
			Act form=new Act(connectioinString, parties);
			DialogResult result = form.ShowDialog();
			form.Dispose();
			updateDataGridViewStorage();
			updateMarketDepartament();

        }

		private void getProductsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn=new MySqlConnection(connectioinString);
			MySqlCommand cmd = new MySqlCommand("", conn);
			//достаем все номера актов
			string select_act = @"USE corparation;
								SELECT number_doc
								FROM documents
								WHERE id_act IS NOT NULL;";
			cmd.CommandText = select_act;
			List<string>num_doc_act = new List<string>();
			conn.Open();
			MySqlDataReader reader=cmd.ExecuteReader();
			while (reader.Read())
			{
				num_doc_act.Add(reader["number_doc"].ToString());
			}
			reader.Close();
			conn.Close();

			//достаем все номера накладных
			string select_order = @"USE corparation;
								SELECT number_doc
								FROM documents
								WHERE id_invoice IS NOT NULL;";
			List<string> num_doc_order = new List<string>();
			conn.Open();
			cmd.CommandText = select_order;
			reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				num_doc_order.Add(reader["number_doc"].ToString());
			}
			reader.Close();
			conn.Close();

			GetProduct form= new GetProduct(num_doc_act, num_doc_order);
			DialogResult result = form.ShowDialog();
			if (result == DialogResult.OK)
			{
				bool flag_act=form.flag_act;
				bool flag_order=form.flag_order;
				string doc=form.number_doc;
				if (flag_act)
				{
					//выдача товара по акту
					//1.получаем id документа с таким номером
					string select_id_doc = @"USE corparation;
										   SELECT id_doc
										   FROM documents
										   WHERE number_doc=@doc;";
					cmd.Parameters.Clear();
					cmd.CommandText = select_id_doc;
					cmd.Parameters.AddWithValue("@doc", doc);
					conn.Open();
					string id_doc = cmd.ExecuteScalar().ToString();
					conn.Close();
					//2. получаем id_партий
					List<string>id_parties = new List<string>();
					string select_id_parties = @"USE corparation;
											   SELECT id_partie
											   FROM connectioin_product_and_documents
											   WHERE id_doc=@id_doc;";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id_doc", id_doc);
					cmd.CommandText= select_id_parties;
					conn.Open();
					reader = cmd.ExecuteReader();
					while(reader.Read())
					{
						id_parties.Add(reader["id_partie"].ToString());
					}
					conn.Close();
					reader.Close();
					//3. удаляем связи партий с документами
					string deleteConnection = @"USE corparation;
													DELETE FROM connectioin_product_and_documents
													WHERE id_doc=@id_doc;";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id_doc", id_doc);
					cmd.CommandText= deleteConnection;
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
					//4.получение id ячейки и изменение ее статуса+ удаление самой партии
					for (int i = 0; i < id_parties.Count(); i++)
					{
						//все связанное с ячейкой
						string select_id_cell = @"USE corparation;
												  SELECT id_cell
												  FROM parties
												  WHERE id_partie=@id";
						cmd.Parameters.Clear();
						cmd.Parameters.AddWithValue("@id", id_parties[i]);
						cmd.CommandText=select_id_cell;
						conn.Open();
						string id_cell= cmd.ExecuteScalar().ToString();
						conn.Close();
						//получение данных ячейки
						string dataCell = @"USE corparation;
											SELECT name_section,number_cell
											FROM cells
											WHERE id_cell=@id_cell;";
						cmd.Parameters.Clear();
						cmd.Parameters.AddWithValue("id_cell", id_cell);
						cmd.CommandText=dataCell;
						conn.Open();
						reader= cmd.ExecuteReader();
						string name_section = "";
						string number_cell="";
						while(reader.Read())
						{
							name_section = reader["name_section"].ToString();
							number_cell = reader["number_cell"].ToString();
						}
						conn.Close();
						reader.Close();
						//изменение статуса ячейки
						string updateCell = @"USE corparation;
											UPDATE cells
											SET name_section=@name_section,number_cell=@number_cell,status_cell='свободно'
											WHERE id_cell=@id_cell;";
						cmd.Parameters.Clear();
						cmd.Parameters.AddWithValue("@name_section", name_section);
						cmd.Parameters.AddWithValue("@number_cell", number_cell);
						cmd.Parameters.AddWithValue("id_cell", id_cell);
						conn.Open();
						cmd.CommandText = updateCell;
						cmd.ExecuteNonQuery();
						conn.Close();

						//все связанное с партией
						string deletePartie = @"USE corparation;
												DELETE FROM parties
												WHERE id_partie=@id_partie;";
						cmd.Parameters.Clear();
						cmd.Parameters.AddWithValue("@id_partie", id_parties[i]);
						cmd.CommandText = deletePartie;
						conn.Open();
						cmd.ExecuteNonQuery();
						conn.Close();
					}
					//5.получаем id акта по документу
					string select_id_act = @"USE corparation;
										   SELECT id_act
										   FROM documents
										   WHERE id_doc=@id_doc;";
					cmd.Parameters.Clear();
					cmd.CommandText = select_id_act;
					cmd.Parameters.AddWithValue("@id_doc", id_doc);
					conn.Open();
					string id_act = cmd.ExecuteScalar().ToString();
					conn.Close() ;
					//получение контента и дату акта для архива
					string selectDateCreate = @"USE corparation;
											  SELECT date_act
											  FROM act
											  WHERE id=@id_act;";
					cmd.Parameters.Clear();
					cmd.CommandText= selectDateCreate;
					cmd.Parameters.AddWithValue("@id_act", id_act);
					conn.Open();
					DateTime dateCreate=Convert.ToDateTime(cmd.ExecuteScalar());
					conn.Close();

					string selectContentAct = @"USE corparation;
												SELECT content
												FROM act
												WHERE id=@id_act;";
					cmd.Parameters.Clear();
					cmd.CommandText = selectContentAct;
					cmd.Parameters.AddWithValue("@id_act", id_act);
					conn.Open();
					string content = cmd.ExecuteScalar().ToString();
					conn.Close();

					//6. удаление самого документа
					string deleteDocument = @"USE corparation;
											DELETE FROM documents
											WHERE id_doc=@id_doc;";
					cmd.Parameters.Clear();
					cmd.CommandText = deleteDocument;
					cmd.Parameters.AddWithValue("@id_doc", id_doc);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
					//7. удаление акта
					string deleteAct = @"USE corparation;
										 DELETE FROM act
										 WHERE id=@id_act;";
					cmd.Parameters.Clear();
					cmd.CommandText = deleteAct;
					cmd.Parameters.AddWithValue("@id_act", id_act);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
					//7. добавление документа в архив
					string insertArchive = @"USE corparation;
										   INSERT INTO archive(type_doc, number_doc,date_create,date_delete,content)
										   VALUES (@type_doc, @number_doc,@date_create,@date_delete,@content);";
					cmd.Parameters.Clear(); 
					cmd.CommandText = insertArchive;
					cmd.Parameters.AddWithValue("@type_doc", "Акт списания");
					cmd.Parameters.AddWithValue("@number_doc",doc);
					cmd.Parameters.AddWithValue("@date_create",dateCreate.Date);
					cmd.Parameters.AddWithValue("@date_delete",DateTime.Now.Date);
					cmd.Parameters.AddWithValue("@content", content);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();   
				}
				else if (flag_order)
				{
					//выдача товара по накладной
					//1.получаем id документа с таким номером
					string select_id_doc = @"USE corparation;
										   SELECT id_doc
										   FROM documents
										   WHERE number_doc=@doc;";
					cmd.Parameters.Clear();
					cmd.CommandText = select_id_doc;
					cmd.Parameters.AddWithValue("@doc", doc);
					conn.Open();
					string id_doc = cmd.ExecuteScalar().ToString();
					conn.Close();
					//2. получаем id_партий и кол-во товаров
					List<List<string>> id_and_counts_parties = new List<List<string>>();//партия, кол-во в отношении, всего сколько
					string select_parties_from_conn = @"USE corparation;
											   SELECT id_partie,count_product
											   FROM connectioin_product_and_documents
											   WHERE id_doc=@id_doc;";
					cmd.Parameters.Clear();
					cmd.Parameters.AddWithValue("@id_doc", id_doc);
					cmd.CommandText = select_parties_from_conn;
					conn.Open();
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						id_and_counts_parties.Add(new List<string>() { reader["id_partie"].ToString(), reader["count_product"].ToString() });
					}
					conn.Close();
					reader.Close();
					//обновить информацию о количестве в таблице партий
					//3.по id партий получаем их полное количество 
					for (int i = 0; i < id_and_counts_parties.Count(); i++)
					{
                        string select_parties_from_parties = @"USE corparation;
											   SELECT count_product
											   FROM parties
											   WHERE id_partie=@id;";
                        cmd.Parameters.Clear();
                        cmd.CommandText = select_parties_from_parties;
                        cmd.Parameters.AddWithValue("@id", id_and_counts_parties[i][0]);
                        conn.Open();
                        string all_count = cmd.ExecuteScalar().ToString();
                        conn.Close();
						id_and_counts_parties[i].Add(all_count);//записываем сколько всего в партии товара
                    }

                    //4. удаляем связи партий с документами и самими партиями
                    string deleteConnection = @"USE corparation;
													DELETE FROM connectioin_product_and_documents
													WHERE id_doc=@id_doc;";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_doc", id_doc);
                    cmd.CommandText = deleteConnection;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //5. обновление информации о партии
                    for (int i = 0; i < id_and_counts_parties.Count(); i++)
					{ 
						string current_id=id_and_counts_parties [i][0];
						decimal current_count = Convert.ToDecimal(id_and_counts_parties[i][2])- Convert.ToDecimal(id_and_counts_parties[i][1]);
						if (current_count == 0)//партию стоит удалить и изменить статус ячейки
						{
                            //все связанное с ячейкой
                            string select_id_cell = @"USE corparation;
												  SELECT id_cell
												  FROM parties
												  WHERE id_partie=@id";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@id", current_id);
                            cmd.CommandText = select_id_cell;
                            conn.Open();
                            string id_cell = cmd.ExecuteScalar().ToString();
                            conn.Close();
                            //получение данных ячейки
                            string dataCell = @"USE corparation;
											SELECT name_section,number_cell
											FROM cells
											WHERE id_cell=@id_cell;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("id_cell", id_cell);
                            cmd.CommandText = dataCell;
                            conn.Open();
                            reader = cmd.ExecuteReader();
                            string name_section = "";
                            string number_cell = "";
                            while (reader.Read())
                            {
                                name_section = reader["name_section"].ToString();
                                number_cell = reader["number_cell"].ToString();
                            }
                            conn.Close();
                            reader.Close();
                            //изменение статуса ячейки
                            string updateCell = @"USE corparation;
											UPDATE cells
											SET name_section=@name_section,number_cell=@number_cell,status_cell='свободно'
											WHERE id_cell=@id_cell;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@name_section", name_section);
                            cmd.Parameters.AddWithValue("@number_cell", number_cell);
                            cmd.Parameters.AddWithValue("id_cell", id_cell);
                            conn.Open();
                            cmd.CommandText = updateCell;
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            //все связанное с партией
                            string deletePartie = @"USE corparation;
												DELETE FROM parties
												WHERE id_partie=@id_partie;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@id_partie", current_id);
                            cmd.CommandText = deletePartie;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
						else //обновляем информацию о количестве товара в партии
						{
                            string updatePartie = @"USE corparation;
												    UPDATE parties
													SET count_product=@current_count
													WHERE id_partie=@current_id;";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@current_id", current_id);
                            cmd.Parameters.AddWithValue("@current_count", current_count);
                            cmd.CommandText = updatePartie;
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
					}
                    //5.получаем id накладной по документу
                    string select_id_invoice = @"USE corparation;
										   SELECT id_invoice
										   FROM documents
										   WHERE id_doc=@id_doc;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = select_id_invoice;
                    cmd.Parameters.AddWithValue("@id_doc", id_doc);
                    conn.Open();
                    string id_invoice = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    //получение id покупателя
                    string select_id_client = @"USE corparation;
										   SELECT client_id
										   FROM invoice
										   WHERE id=@id_invoice;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = select_id_client;
                    cmd.Parameters.AddWithValue("@id_invoice", id_invoice);
                    conn.Open();
                    string client_id = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    //получение контента и дату акта для архива
                    string selectDateCreate = @"USE corparation;
											  SELECT date_invoice
											  FROM invoice
											  WHERE id=@id_invoice;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = selectDateCreate;
                    cmd.Parameters.AddWithValue("@id_invoice", id_invoice);
                    conn.Open();
                    DateTime dateCreate = Convert.ToDateTime(cmd.ExecuteScalar());
                    conn.Close();
                    // в контенте вся информация 
                    string selectContentInvoice = @"USE corparation;
												SELECT content
												FROM invoice
												WHERE id=@id_invoice;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = selectContentInvoice;
                    cmd.Parameters.AddWithValue("@id_invoice", id_invoice);
                    conn.Open();
                    string content = cmd.ExecuteScalar().ToString();
                    conn.Close();
					
                    //6. удаление самого документа
                    string deleteDocument = @"USE corparation;
											DELETE FROM documents
											WHERE id_doc=@id_doc;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteDocument;
                    cmd.Parameters.AddWithValue("@id_doc", id_doc);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //7. удаление накладной
                    string deleteAct = @"USE corparation;
										 DELETE FROM invoice
										 WHERE id=@id_invoice;";
                    cmd.Parameters.Clear();
                    cmd.CommandText = deleteAct;
                    cmd.Parameters.AddWithValue("@id_invoice", id_invoice);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //7. добавление документа в архив
                    string insertArchive = @"USE corparation;
										   INSERT INTO archive(type_doc, number_doc,date_create,date_delete,content)
										   VALUES (@type_doc, @number_doc,@date_create,@date_delete,@content);";
                    cmd.Parameters.Clear();
                    cmd.CommandText = insertArchive;
                    cmd.Parameters.AddWithValue("@type_doc", "Накладная");
                    cmd.Parameters.AddWithValue("@number_doc", doc);
                    cmd.Parameters.AddWithValue("@date_create", dateCreate.Date);
                    cmd.Parameters.AddWithValue("@date_delete", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@content", content);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
					//8.добавление информации в таблицу чеков
					string insertCheque= @"USE corparation;
										   INSERT INTO cheque(number_cheque,date_create,content,client_id)
										   VALUES (@number_cheque,@date_create,@content,@client_id);";
					cmd.Parameters.Clear();
					cmd.CommandText = insertCheque;
                    cmd.Parameters.AddWithValue("@number_cheque", doc);
                    cmd.Parameters.AddWithValue("@date_create", dateCreate.Date);
                    cmd.Parameters.AddWithValue("@content", content);
                    cmd.Parameters.AddWithValue("@client_id", client_id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
			}
			form.Dispose();
			updateDataGridViewStorage();
			updateCheque();
            updateMarketDepartament();
        }

		private void ArchiveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MySqlConnection conn = new MySqlConnection(connectioinString);
			string select_archive = @"USE corparation;
									  SELECT 
										id,
										type_doc AS 'Тип документа',
										number_doc AS 'Номер документа',
										date_create AS 'Дата создания документа',
										date_delete AS 'Дата занесения в архив',
										content
									  FROM archive;";
			conn.Open();
			MySqlCommand cmd=new MySqlCommand(select_archive, conn);
			MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
			DataTable dataTable = new DataTable();
			adapter.Fill(dataTable);
			conn.Close();
			Archive form = new Archive(dataTable);
			form.ShowDialog();
			form.Dispose();
		}
		

        private void button_profit_Click(object sender, EventArgs e)
        {
			//получение дат с формы и проверка положительности периода
			DateTime date1 = dateTimePicker1.Value.Date;
			DateTime date2 = dateTimePicker2.Value.Date;
			if (date1 > date2)
			{
				MessageBox.Show("Вторая дата не может быть меньше первой", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			else
			{
				
				//1. нужно достать все зазазы за этот период
				MySqlConnection conn = new MySqlConnection(connectioinString);
				MySqlCommand cmd = new MySqlCommand("", conn);
				string selectOrderFromArchive = @"USE corparation;
												  SELECT content
												  FROM archive
												  WHERE type_doc='Накладная' AND date_delete BETWEEN @date1 AND @date2;";
				cmd.CommandText = selectOrderFromArchive;
				List<string>orders = new List<string>();
				cmd.Parameters.AddWithValue("@date1", date1);
                cmd.Parameters.AddWithValue("@date2", date2);
				conn.Open();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					orders.Add(reader["content"].ToString());
				}
				conn.Close();	
				reader.Close();
				//теперь их надо распаковать
				Dictionary<string,decimal>result = new Dictionary<string,decimal>();
				decimal all_profit = 0;
				for (int k = 0; k < orders.Count(); k++)
				{
                    //здесь распаковка
                    //извлечение контента
                    string[] rows = orders[k].Split('\n');//отделили строки
                    for (int i = 0; i < rows.Length - 1; i++)
                    {
                        string[] parts_row = rows[i].Split(';');
                        string[] result_row = new string[parts_row.Length];//0-Название продукта,1-количества,2-ед изм,3-цена
                        for (int j = 0; j < parts_row.Length; j++)
                        {
                            int index = parts_row[j].IndexOf(": ") + ": ".Length;
                            result_row[j] = parts_row[j].Substring(index);
                        }
						//нужно проверить нет ли такого продукта в списке
						if (!result.ContainsKey(result_row[0]))//добавляем новый товар в словарь
						{
							decimal profit = Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
							all_profit += profit;
							result.Add(result_row[0], profit);
						}
						else //если такой есть, обновляем прибыль с него
						{
							decimal profit = result[result_row[0]];
							profit+= Convert.ToDecimal(result_row[3]) - Convert.ToDecimal(result_row[4]);
							all_profit += profit;
                            result[result_row[0]]=profit;
                        }
                    }
                }
				textBox_allProfit.Text = all_profit.ToString();//вывод всей прибыли
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add("Товар", typeof(string));
				dataTable.Columns.Add("Прибыль за товар",typeof(string));
                // Перебор всех пар ключ-значение
                foreach (KeyValuePair<string, decimal> item in result)
                {
                    DataRow row=dataTable.NewRow();
					row["Товар"]=item.Key;
					row["Прибыль за товар"]= item.Value.ToString();
					dataTable.Rows.Add(row);
                }
				dataGridView_profit.DataSource = dataTable;
            }
            updateMarketDepartament();
        }

        private void orderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectioinString);
            MySqlCommand cmd = new MySqlCommand("", conn);
            //1 выборка всех клиентов и связей 
            string selectClients = @"USE corparation;
                         SELECT 
                             clients.id,
                            clients.type_client,
                            legal_entity.id_company AS id_client,
                            legal_entity.name_company AS name
                         FROM legal_entity
                         INNER JOIN clients ON legal_entity.id_company=clients.id_legal_entity
                         
                         UNION ALL
                         
                         SELECT 
                             clients.id,
                            clients.type_client,
                            physical_person.id_person AS id_client,
                            CONCAT_WS(' ',physical_person.firstname,physical_person.secondname,physical_person.thirdname) AS name
                         FROM physical_person
                         INNER JOIN clients ON clients.id_physical_person=physical_person.id_person;";
            cmd.CommandText = selectClients;
            List<List<string>> clients = new List<List<string>>();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new List<string>() { reader["id"].ToString(), reader["type_client"].ToString(), reader["id_client"].ToString(), reader["name"].ToString() });
            }
            conn.Close();
            reader.Close();
            //запрос товаров
            cmd.CommandText = query.select_count_product_for_order;
            cmd.Parameters.Clear();
            List<List<string>> catalog = new List<List<string>>();
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                catalog.Add(new List<string>() { reader["name_section"].ToString(), reader["id_product"].ToString(), reader["name_product"].ToString(), reader["counts"].ToString(), reader["unit_of_measurement"].ToString(), reader["sale_price"].ToString() });
            }
            conn.Close();
            reader.Close();
            Order form = new Order(clients, catalog);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {

                List<List<string>> basket = form.order;
                string client_id = form.client_id;
                DateTime time = DateTime.Now.Date;
                string number_order = "ЗАКАЗ-" + new Random().Next(1, 5000).ToString("D4");
                string insertOrder = @"USE corparation;
                         INSERT INTO invoice(number_order,content,client_id,date_invoice)
                         VALUES (@number_order,@content,@client_id,@date_invoice);";
                cmd.CommandText = insertOrder;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@number_order", number_order);
                cmd.Parameters.AddWithValue("@content", "");
                cmd.Parameters.AddWithValue("@client_id", client_id);
                cmd.Parameters.AddWithValue("@date_invoice", time);
                conn.Open();
                cmd.ExecuteNonQuery();//добавление заказа
                conn.Close();
                //формирование документа
                string number_doc = "ДОКУМЕНТ-" + new Random().Next(0, 10000).ToString("D5");
                string type_doc = "Заказ";
                //получение id_invoice
                string select_ID_order = @"USE corparation;
                             SELECT id
                             FROM invoice
                             WHERE number_order=@number_order;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@number_order", number_order);
                cmd.CommandText = select_ID_order;
                conn.Open();
                string id_order = cmd.ExecuteScalar().ToString();
                conn.Close();
                //добавление документа
                string insertDoc = @"USE corparation;
                         INSERT INTO documents(number_doc,type_doc,id_invoice)
                         VALUES (@number_doc,@type_doc,@id_invoice)";
                cmd.Parameters.Clear();
                cmd.CommandText = insertDoc;
                cmd.Parameters.AddWithValue("@number_doc", number_doc);
                cmd.Parameters.AddWithValue("@type_doc", type_doc);
                cmd.Parameters.AddWithValue("@id_invoice", id_order);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                //достаем id_документа для связей
                string select_ID_doc = @"USE corparation;
                             SELECT id_doc
                             FROM documents
                             WHERE number_doc=@number_doc;";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@number_doc", number_doc);
                cmd.CommandText = select_ID_doc;
                conn.Open();
                string id_doc = cmd.ExecuteScalar().ToString();
                conn.Close();



                //формирование контента заказа
                string content = "";
                //теперь надо правильно установить связи документа с заказом
                for (int i = 0; i < basket.Count(); i++)
                {
					content += "Название продукта: " + basket[i][0] + ";Количество: " + basket[i][1] + ";Единица измерения: " + basket[i][2] + ";Цена продажи за все количество: ";
					decimal finish_price = Convert.ToDecimal(basket[i][1]) * Convert.ToDecimal(basket[i][3]);
					content += finish_price.ToString();
					content += ";Цена закупки за все количество: ";


                    string name_product = basket[i][0];
                    decimal count_product = Convert.ToDecimal(basket[i][1]);
                    //теперь надо достать все партии нужного нам продукта и их id+фильтрация по дате
                    string selectPatrie = @"USE corparation;
                                SELECT 
                                    parties.id_partie,
									parties.purshase_price,
                                    parties.count_product-COALESCE((SELECT SUM(connectioin_product_and_documents.count_product)
                                                FROM connectioin_product_and_documents
                                                            WHERE connectioin_product_and_documents.id_partie=parties.id_partie
                                               ),0) as counts
                                FROM products
                                INNER JOIN parties ON parties.id_product=products.id_product
                                WHERE parties.status!='Списана' AND parties.storage_date>=NOW() AND products.name_product=@product AND products.sale_price IS NOT NULL
                                ORDER BY parties.storage_date;                         ";
                    cmd.Parameters.Clear();
                    cmd.CommandText = selectPatrie;
                    cmd.Parameters.AddWithValue("@product", name_product);
                    List<List<string>> parties = new List<List<string>>();
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        parties.Add(new List<string>() { reader["id_partie"].ToString(), reader["purshase_price"].ToString(), reader["counts"].ToString(), });
                    }
                    conn.Close();
                    reader.Close();
                    //получили партии, теперь надо их распределить
                    List<KeyValuePair<string, string>> res_conn = new List<KeyValuePair<string, string>>();
                    decimal start_price = 0;
                    for (int k = 0; k < parties.Count(); k++)
                    {
                        if (count_product == 0)
                        { break; }
                        if (Convert.ToDecimal(parties[k][2]) >= count_product)
                        {
                            res_conn.Add(new KeyValuePair<string, string>(parties[k][0], count_product.ToString()));
							start_price += Convert.ToDecimal(count_product) * Convert.ToDecimal(parties[k][1]);
                            count_product = 0;
                        }
                        else//партия полностью не покрывает кол-во в заказе
                        {
                            res_conn.Add(new KeyValuePair<string, string>(parties[k][0], parties[k][2]));
                            start_price += Convert.ToDecimal(parties[k][2]) * Convert.ToDecimal(parties[k][1]);
                            count_product -= Convert.ToDecimal(parties[k][2]);
                        }
                    }

					content+=start_price.ToString() + "\n";

                    //добавляем записи в таблицу связей
                    for (int k = 0; k < res_conn.Count(); k++)
                    {
                        string insertConnection = @"USE corparation;
                                        INSERT INTO connectioin_product_and_documents(id_partie,count_product,id_doc)
                                        VALUES (@id_partie,@count_product,@id_doc)";
                        cmd.Parameters.Clear();
                        cmd.CommandText = insertConnection;
                        cmd.Parameters.AddWithValue("@id_partie", res_conn[k].Key);
                        cmd.Parameters.AddWithValue("@count_product", Convert.ToDecimal(res_conn[k].Value));
                        cmd.Parameters.AddWithValue("@id_doc", id_doc);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    } 
                }
				string updateContentInInvoice = @"USE corparation;
												  UPDATE invoice
												  SET content=@content
												  WHERE id=@id_order;";
				cmd.CommandText= updateContentInInvoice;
				cmd.Parameters.Clear();
				cmd.Parameters.AddWithValue("@id_order", id_order);
                cmd.Parameters.AddWithValue("@content", content);
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();

            }
            form.Dispose();
            updateMarketDepartament();
        }

        private void RegClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //проверку есть ли такой типок будем через запрос бд
            RegistrationClient reg = new RegistrationClient(connectioinString);
            DialogResult result = reg.ShowDialog();
            if (result == DialogResult.OK)
            {
                MySqlConnection conn = new MySqlConnection(connectioinString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("", conn);
                int flag = reg.flag;
                if (flag == 1)
                {
                    //регистрируем физ лицо
                    string firstname = reg.firstname;
                    string secondname = reg.secondname;
                    string thirdname = reg.thirdname;
                    string serie_passport = reg.serie_passport;
                    string number_passport = reg.number_passport;
                    string address = reg.address;
                    string INN_phys = reg.INN_phys;
                    //добавляем пользователя в систему
                    cmd.Parameters.Clear();
                    cmd.CommandText = query.insertPhysPerson;
                    cmd.Parameters.AddWithValue("@thirdname", thirdname);
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@secondname", secondname);
                    cmd.Parameters.AddWithValue("@serie_passport", serie_passport);
                    cmd.Parameters.AddWithValue("@number_passport", number_passport);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@INN", INN_phys);
                    cmd.ExecuteNonQuery();
                    //теперь надо добавить ссылку на него в таблицу clients
                    //1. получаем id добавленной записи
                    cmd.CommandText = query.select_id_PhysPerson;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@serie_passport", serie_passport);
                    cmd.Parameters.AddWithValue("@number_passport", number_passport);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@INN", INN_phys);
                    string id = Convert.ToString(cmd.ExecuteScalar());
                    //2. добавляем запись в таблицу clients
                    cmd.CommandText = query.insert_client_PhysPerson;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_physical_person", id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    //регистрируем юр лицо 
                    string nameCompany = reg.nameCompany;
                    string addressCompany = reg.addressCompany;
                    string bank = reg.bank;
                    string INN_UR = reg.INN_UR;
                    //добавляем компанию в систему
                    cmd.CommandText = query.insert_legal_entity;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name_company", nameCompany);
                    cmd.Parameters.AddWithValue("@address", addressCompany);
                    cmd.Parameters.AddWithValue("@bank_data", bank);
                    cmd.Parameters.AddWithValue("@INN", INN_UR);
                    cmd.ExecuteNonQuery();
                    //теперь надо добавить ссылку на него в таблицу clients
                    //1. получаем id добавленной записи
                    cmd.CommandText = query.select_id_legal_entity;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@name_company", nameCompany);
                    cmd.Parameters.AddWithValue("@address", addressCompany);
                    cmd.Parameters.AddWithValue("@bank_data", bank);
                    cmd.Parameters.AddWithValue("@INN", INN_UR);
                    string id = Convert.ToString(cmd.ExecuteScalar());
                    //2. добавляем запись в таблицу clients
                    cmd.CommandText = query.insert_client_legal_entity;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_legal_entity", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            reg.Dispose();
        }

        private void DeleteOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectioinString);
            MySqlCommand cmd = new MySqlCommand("", conn);
            //1 выборка всех клиентов и связей у которых есть заказы
            string selectClients = @"USE corparation;
                         SELECT 
                             clients.id,
                            clients.type_client,
                            legal_entity.id_company AS id_client,
                            legal_entity.name_company AS name
                         FROM legal_entity
                         INNER JOIN clients ON legal_entity.id_company=clients.id_legal_entity
                         INNER JOIN invoice ON invoice.client_id=clients.id
                         
                         UNION
                         
                         SELECT 
                             clients.id,
                            clients.type_client,
                            physical_person.id_person AS id_client,
                            CONCAT_WS(' ',physical_person.firstname,physical_person.secondname,physical_person.thirdname) AS name
                         FROM physical_person
                         INNER JOIN clients ON clients.id_physical_person=physical_person.id_person
                         INNER JOIN invoice ON invoice.client_id=clients.id;";
            cmd.CommandText = selectClients;
            List<List<string>> clients = new List<List<string>>();
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new List<string>() { reader["id"].ToString(), reader["type_client"].ToString(), reader["id_client"].ToString(), reader["name"].ToString() });
            }
            if (clients.Count() == 0)
            {
                MessageBox.Show("В системе нет активных заказов", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                reader.Close();
                return;
            }
            conn.Close();
            reader.Close();
            //выборка заказов
            string selectOrder = @"USE corparation;
                        SELECT 
                            invoice.id,
                            documents.id_doc,
                            documents.number_doc,
                            DATE_FORMAT(invoice.date_invoice,'%d-%m-%Y') as date_invoice
                        FROM invoice
                        INNER JOIN  documents ON documents.id_invoice=invoice.id
                        WHERE invoice.client_id=@client_id;";
            List<List<string>> order = new List<List<string>>();
            for (int i = 0; i < clients.Count(); i++)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@client_id", clients[i][0]);
                cmd.CommandText = selectOrder;
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    order.Add(new List<string>() { reader["id"].ToString(), reader["id_doc"].ToString(), reader["number_doc"].ToString(), reader["date_invoice"].ToString(), clients[i][0] });
                }
                conn.Close();
                reader.Close();
            }
            DeleteOrder form = new DeleteOrder(clients, order, connectioinString);
            form.ShowDialog();
            form.Dispose();
        }
        private void updateCheque()
        {
            MySqlConnection conn = new MySqlConnection(connectioinString);
            MySqlCommand cmd = new MySqlCommand("", conn);
            string selectInfoCheque = @"USE corparation;
                                SELECT 
                                    cheque.number_cheque AS 'Номер чека',
                                    cheque.date_create AS 'Дата покупки',
                                    CONCAT('В покупке позиций: ', LENGTH(cheque.content)-LENGTH(REPLACE(cheque.content,'\n',''))) AS 'Содержимое покупки',
                                    CONCAT_WS(' ',physical_person.firstname,physical_person.secondname,physical_person.thirdname) AS 'Покупатель',
                                    cheque.content
                                FROM cheque
                                INNER JOIN clients ON clients.id=cheque.client_id
                                INNER JOIN physical_person ON physical_person.id_person=clients.id_physical_person
                                UNION 
                                SELECT 
                                    cheque.number_cheque AS 'Номер чека',
                                    cheque.date_create AS 'Дата покупки',
                                    CONCAT('В покупке позиций: ', LENGTH(cheque.content)-LENGTH(REPLACE(cheque.content,'\n',''))) AS 'Содержимое покупки',
                                    legal_entity.name_company AS 'Покупатель',
                                    cheque.content
                                FROM cheque
                                INNER JOIN clients ON clients.id=cheque.client_id
                                INNER JOIN legal_entity ON legal_entity.id_company=clients.id_legal_entity; ";
            cmd.CommandText = selectInfoCheque;
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
			adapter.Fill(dt);
			dt.Columns.Add("Цена", typeof(decimal));
			//перебираем записи, у каждой делаем распаковку контента и записываем цену
			for (int k = 0; k < dt.Rows.Count; k++)
			{
				DataRow row = dt.Rows[k];
				string content = row["content"].ToString();
                //дальше находим цену через распаковку контента
                decimal price = 0;

                //здесь распаковка
                //извлечение контента
                string[] rows = content.Split('\n');//отделили строки
                for (int i = 0; i < rows.Length - 1; i++)
                {
                    string[] parts_row = rows[i].Split(';');
                    string[] result_row = new string[parts_row.Length];//0-Название продукта,1-количества,2-ед изм,3-цена продажи, 4-цена закупки
                    for (int j = 0; j < parts_row.Length; j++)
                    {
                        int index = parts_row[j].IndexOf(": ") + ": ".Length;
                        result_row[j] = parts_row[j].Substring(index);
                    }
					price += Convert.ToDecimal(result_row[3]);
                }
				dt.Rows[k]["Цена"]= price;
            }

            dataGridView_cheque.DataSource = dt;
            dataGridView_cheque.Columns["content"].Visible = false;
            updateMarketDepartament();
        }
        private void button_viewCheque_Click(object sender, EventArgs e)
        {
            if (textBox_number_cheque.Text == "")
            {
                MessageBox.Show("Сначала необходимо выбрать чек", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
				//открытие формы для просмотра
				MySqlConnection conn = new MySqlConnection(connectioinString);
				MySqlCommand cmd = new MySqlCommand("", conn);
				cmd.Parameters.Clear();
				cmd.CommandText = @"USE corparation;
                                SELECT 
                                    cheque.number_cheque AS 'Номер чека',
                                    cheque.date_create AS 'Дата покупки',
                                    CONCAT_WS(' ',physical_person.firstname,physical_person.secondname,physical_person.thirdname) AS 'Покупатель',
                                    cheque.content
                                FROM cheque
                                INNER JOIN clients ON clients.id=cheque.client_id
                                INNER JOIN physical_person ON physical_person.id_person=clients.id_physical_person
								WHERE cheque.number_cheque=@number
                                UNION 
                                SELECT 
                                    cheque.number_cheque AS 'Номер чека',
                                    cheque.date_create AS 'Дата покупки',
                                    legal_entity.name_company AS 'Покупатель',
                                    cheque.content
                                FROM cheque
                                INNER JOIN clients ON clients.id=cheque.client_id
                                INNER JOIN legal_entity ON legal_entity.id_company=clients.id_legal_entity
								WHERE cheque.number_cheque=@number; ";
				cmd.Parameters.AddWithValue("@number", textBox_number_cheque.Text);
                List<string> data = new List<string>();
				conn.Open();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{ 
					data.Add(reader["Номер чека"].ToString());
                    data.Add(reader["Покупатель"].ToString());
                    data.Add(reader["Дата покупки"].ToString());
                    data.Add(reader["content"].ToString());
                }
				conn.Close();
				reader.Close();
				ViewCheque form = new ViewCheque(data[0], data[1], DateTime.Parse(data[2]), data[3]);
				form.ShowDialog();
				form.Dispose();
            }
        }

        private void dataGridView_cheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e.RowIndex - индекс строки, по которой кликнули
            // e.ColumnIndex - индекс колонки, по которой кликнули

            if (e.RowIndex >= 0)  // Проверка, что кликнут не по заголовку
            {
                DataGridViewRow row = dataGridView_cheque.Rows[e.RowIndex];
                textBox_number_cheque.Text = row.Cells["Номер чека"].Value.ToString();
            }
        }
    }
}
