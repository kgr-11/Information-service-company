using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DB2
{
    internal class BasicQuery
    {
        public BasicQuery() { }
        //запросы создания 
        //создание бд
        public string db = @"CREATE DATABASE IF NOT EXISTS corparation;";
        //создание таблиц
        public string createTableLegalUntity = @"USE corparation;CREATE TABLE IF NOT EXISTS legal_entity
                                                 (
	                                                id_company INT PRIMARY KEY AUTO_INCREMENT,
                                                    name_company VARCHAR(200) NOT NULL,
                                                    address VARCHAR(300) NOT NULL,
                                                    bank_data VARCHAR(30) NOT NULL,
                                                    INN VARCHAR(30) NOT NULL
                                                  );";
        public string createTablePhysicalPerson = @"USE corparation;CREATE TABLE IF NOT EXISTS physical_person-- ЮР ЛИЦО
                                                    (
	                                                    id_person INT PRIMARY KEY AUTO_INCREMENT,
                                                        firstname VARCHAR(50) NOT NULL,
	                                                    secondname VARCHAR(50) NOT NULL,
	                                                    thirdname VARCHAR(50) NOT NULL,
                                                        serie_passport VARCHAR(20) NOT NULL,
                                                        number_passport VARCHAR(30) NOT NULL,
                                                        address VARCHAR(300) NOT NULL,
                                                        INN VARCHAR(30) NOT NULL
                                                      );";
        public string createTableClients = @"USE corparation;CREATE TABLE IF NOT EXISTS clients
                                                    (
                                                    	id INT PRIMARY KEY AUTO_INCREMENT,
                                                        type_client VARCHAR(50) NOT NULL,
                                                        id_legal_entity INT,
                                                        id_physical_person INT,
                                                        FOREIGN KEY(id_legal_entity) REFERENCES legal_entity(id_company),
                                                        FOREIGN KEY(id_physical_person) REFERENCES physical_person(id_person)
                                                    );";
        public string createTableInvoice = @"USE corparation;CREATE TABLE IF NOT EXISTS invoice
                                             (
                                             	id INT PRIMARY KEY AUTO_INCREMENT,
                                                 content TEXT NOT NULL,
                                                 client_id INT NOT NULL,
                                                 date_invoice DATE NOT NULL,
                                                 FOREIGN KEY(client_id) REFERENCES clients(id)
                                             );";
        public string createTableAct = @"USE corparation;CREATE TABLE IF NOT EXISTS act
                                        (
                                        	id INT PRIMARY KEY AUTO_INCREMENT,
                                            content TEXT NOT NULL,
                                            date_act DATE NOT NULL
                                        );";
        public string createTableDocuments = @"USE corparation;CREATE TABLE IF NOT EXISTS documents
                                                (
                                                	id_doc INT PRIMARY KEY AUTO_INCREMENT,
                                                    number_doc VARCHAR(50) NOT NULL UNIQUE,
                                                    type_doc VARCHAR(100) NOT NULL,
                                                    id_act INT,
                                                    id_invoice INT,
                                                    FOREIGN KEY(id_act) REFERENCES act(id),
                                                    FOREIGN KEY(id_invoice) REFERENCES invoice(id)
                                                );";
        public string createTableCells = @"USE corparation;CREATE TABLE IF NOT EXISTS cells
                                            (
	                                        id_cell INT PRIMARY KEY AUTO_INCREMENT,
                                            name_section VARCHAR(100) NOT NULL,
	                                        number_cell VARCHAR(10) NOT NULL
                                            );";

        public string createTableProducts=@"USE corpration;
                                            CREATE TABLE IF NOT EXISTS products
                                            (
                                            id_product INT PRIMARY KEY AUTO_INCREMENT,
                                            name_product VARCHAR(100) NOT NULL,
                                            sale_price DECIMAL(19,2)
                                            );";
        public string createTableParties = @"USE corparation;CREATE TABLE IF NOT EXISTS parties
                                             (
                                              id_partie INT PRIMARY KEY AUTO_INCREMENT,
                                              number_partie VARCHAR(50) NOT NULL UNIQUE,
                                              count_product DECIMAL(19,3) NOT NULL,
                                              unit_of_measurement VARCHAR(50) NOT NULL,
                                              delivery_date DATE NOT NULL,
                                              storage_date DATE NOT NULL,
                                              temperature INT NOT NULL,
                                              purshase_price DECIMAL(19,2) NOT NULL,s
                                              id_cell INT NOT NULL,
                                              id_product INT NOT NULL,
                                              FOREIGN KEY(id_cell) REFERENCES CELLS(id_cell),
                                              FOREIGN KEY(id_product) REFERENCES products(id_product)
                                             );";
        public string connectioin_product_and_documents = @"USE corparation;CREATE TABLE connectioin_product_and_documents
                                                            (
                                                            id INT PRIMARY KEY AUTO_INCREMENT,
                                                            id_product INT NOT NULL,
                                                            id_doc INT NOT NULL,
                                                            FOREIGN KEY(id_partie) REFERENCES parties(id_partie),
                                                            FOREIGN KEY(id_doc) REFERENCES documents(id_doc)
                                                            );";



        //обновление цены
        public string updateSalePrice = @"USE corparation;
                                          UPDATE products
                                          SET sale_price=@price
                                          WHERE id_product=@id;";
        //запросы на вставку
        public string insertPartie = @"USE corparation;
                                       INSERT INTO parties (count_product,unit_of_measurement,delivery_date,storage_date,temperature,purshase_price,id_cell,id_product,number_partie,status)
                                       VALUES (@count_product,@unit_of_measurement,@delivery_date,@storage_date,@temperature,@purshase_price,@id_cell,@id_product,@number_partie,'В продаже');";
        //запросы на выборку
        public string select_id_PhysPerson = @"USE corparation;SELECT id_person
                                       FROM physical_person
                                       WHERE serie_passport=@serie_passport AND number_passport=number_passport AND address=address AND INN=@INN;";
        public string select_id_legal_entity = @"USE corparation;
                                        SELECT id_company
                                        FROM legal_entity
                                        WHERE name_company=@name_company AND address=@address AND bank_data=@bank_data AND INN=@INN;";
        //запрос на назначение продажной цены товару
        public string forSalePrice = @"USE corparation;
                                       SELECT 
                                            product.id_product,
                                            product.name_product,
                                            product.purshase_price,
                                            cells.name_section
                                       FROM product
                                       INNER JOIN cells ON product.id_cell=cells.id_cell;";
        //вывод информации о партиях на складе
        public string selectDataAboutParties = @"USE corparation;
                                                 SELECT 
                                                 	products.name_product AS 'Название продукта',
                                                     parties.number_partie AS 'Номер партии',
                                                     CONCAT(parties.count_product,' ',parties.unit_of_measurement) AS 'Количество',
                                                     parties.delivery_date AS 'Дата поступления',
                                                     parties.storage_date AS 'Дата истечения срока',
                                                     parties.temperature AS 'Температура хранения',
                                                     cells.name_section AS 'Секция',
                                                     cells.number_cell AS 'Ячейка',
                                                     CASE
                                                 		WHEN act.id IS NULL THEN 'В продаже'
                                                         ELSE 'Списана'
                                                     END AS 'Статус'
                                                 FROM parties
                                                 INNER JOIN products ON products.id_product=parties.id_product
                                                 INNER JOIN cells ON cells.id_cell=parties.id_cell
                                                 LEFT JOIN connectioin_product_and_documents ON connectioin_product_and_documents.id_partie=parties.id_partie
                                                 LEFT JOIN documents ON connectioin_product_and_documents.id_doc=documents.id_doc
                                                 LEFT JOIN act ON act.id=documents.id_act;    ";
        //вывод информации об актуальной продажной цены
        public string selectActualPrice = @"USE corparation;
                                            SELECT 
                                            	products.name_product AS 'Название товара',
                                                products.sale_price AS 'Продажная цена'
                                            FROM products
                                            WHERE products.sale_price IS NOT NULL
                                            ORDER BY products.name_product;  ";
        //запросы на вставку клиентов
        public string insertPhysPerson = @"USE corparation;
                                 INSERT INTO physical_person(firstname,secondname,thirdname,serie_passport,number_passport,address,INN)
                                 VALUES (@firstname,@secondname,@thirdname,@serie_passport,@number_passport,@address,@INN);";

        public string insert_legal_entity = @"USE corparation;
                                     INSERT INTO legal_entity(name_company,address,bank_data,INN)
                                     VALUES (@name_company,@address,@bank_data,@INN);";

        public string insert_client_PhysPerson = @"USE corparation;
                                            INSERT INTO clients(type_client,id_physical_person)
                                            VALUES ('Физическое лицо',@id_physical_person);";

        public string insert_client_legal_entity = @"USE corparation;
                                    INSERT INTO clients(type_client,id_legal_entity)
                                    VALUES ('Юридическое лицо',@id_legal_entity);";
        public string select_count_product_for_order = @"USE corparation;
                                                 SELECT 
                                                     cells.name_section,
                                                     products.id_product,
                                                     products.name_product,
                                                     SUM(parties.count_product-COALESCE((SELECT 
                                                               SUM(connectioin_product_and_documents.count_product)
                                                              FROM connectioin_product_and_documents
                                                                             WHERE parties.id_partie=connectioin_product_and_documents.id_partie
                                                              GROUP BY connectioin_product_and_documents.id_partie),0)) AS counts,
                                                     parties.unit_of_measurement,
                                                     products.sale_price
                                                 FROM products
                                                 INNER JOIN parties ON products.id_product=parties.id_product
                                                 INNER JOIN cells ON parties.id_cell=cells.id_cell
                                                 WHERE parties.storage_date>=NOW() AND parties.status!='Списана' -- не испорчена ли она, если она будет списана, это будет видно в количестве продуктов в таблице связей и все будет работать правильно
                                                 GROUP BY products.id_product,products.name_product,products.sale_price;";
    }
}
