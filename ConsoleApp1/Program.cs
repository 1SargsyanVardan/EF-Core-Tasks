using Microsoft.EntityFrameworkCore;
using ConsoleApp1;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System;
using Microsoft.Identity.Client;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata;

using (TasksContext ts = new TasksContext())
{
    //task 1 adding new customers
    /*Customer cust1 = new Customer("Vardan", "Hrazdan", "+37494831910", "Vardan.sargsyan@mail.com", "Active");
    Customer cust2 = new Customer("Vahe", "Yerevan", "+37494865610", "dasdsyan@mail.com", "Inactive");
    Customer cust3 = new Customer("Karen", "Yerevan", "+37498561910", "Vsdsdn@mail.com", "Active");
    Customer cust4 = new Customer("Ani", "Yerevan", "+37494845565", "aaaaa@mail.com", "Inactive");
    ts.Customers.Add(cust1);
    ts.Customers.Add(cust2);
    ts.Customers.Add(cust3);
    ts.Customers.Add(cust4);

    ts.SaveChanges();*/
    //task1...Retrieve Active Customers
    /*var customer = ts.Customers.Where(x => x.Status == "Active");
    foreach (var c in customer)
        Console.WriteLine($"{c.Name} - {c.Address} - {c.Status}");*/

    //Task2  adding new products
    /*Product product1 = new Product { Name = "Laptop", Price = 110, StockQuantity = 12 };
    Product product2 = new Product { Name = "Iphone", Price = 80, StockQuantity = 23 };
    Product product3 = new Product { Name = "Samsung", Price = 120, StockQuantity = 7 };
    ts.Products.Add(product1);
    ts.Products.Add(product2);
    ts.Products.Add(product3);
    ts.SaveChanges();*/

    //task2...Get High-Value Products
    /*var prod = ts.Products.Where(p => p.Price > 100);
    foreach (var c in prod)
        Console.WriteLine(c.Name + " " + c.Price);*/

    //Tas1 adding new orders
    /*Order order1 = new Order { Date = new DateTime(2008, 5, 1, 8, 30, 52), CustomerId = 1, TotalAmount = 120, Status = "paid" };
    Order order2 = new Order { Date = new DateTime(2023, 8, 5, 8, 30, 52), CustomerId = 3, TotalAmount = 32, Status = "paid" };
    Order order3 = new Order { Date = new DateTime(2008, 8, 8, 8, 30, 52), CustomerId = 3, TotalAmount = 123, Status = "paid" };
    Order order4 = new Order { Date = new DateTime(2023, 8, 8, 8, 30, 52), CustomerId = 2, TotalAmount = 73, Status = "paid" };
    ts.Orders.Add(order1);
    ts.Orders.Add(order2);
    ts.Orders.Add(order3);
    ts.Orders.Add(order4);
    ts.SaveChanges();*/

    //Task3...Fetch Recent Orders
    /*var sevenDaysAgo = DateTime.Now.AddDays(-8);
    var ord = ts.Orders.Where(o => o.Date >= sevenDaysAgo).ToList();
    foreach (var o in ord)
        Console.WriteLine(o.Date + " Customer: " + o.CustomerId);*/

    //Task4... Sort Products by Price
    /*var prod = ts.Products.OrderBy(p => p.Price);
    foreach (var c in prod)
        Console.WriteLine(c.Name + " " + c.Price);*/

    //Task5... Sort Orders by Total Amount
    /*var ord = ts.Orders.OrderByDescending(o => o.TotalAmount);
    foreach (var o in ord)
        Console.WriteLine(o.Date + " CustomerId: " + o.CustomerId + " TotalAmount: " + o.TotalAmount);*/

    //Task6...Sort Customers Alphabetically
    /*var cust = ts.Customers.OrderBy(x => x.Name).ToList();
    foreach (var c in cust)
        Console.WriteLine($"{c.Name} - {c.Address} - {c.Status}");*/

    //Task7...Retrieve Customer Orders
    /*var OrdersAndCustomers = ts.Customers.Join(ts.Orders,
               c => c.Id,
               o => o.CustomerId,
               (o, c) => new
               {
                   Name = o.Name,
                   Addres = o.Address,
                   Number = o.ContactNumber,
                   Date = c.Date,
                   Amount = c.TotalAmount,
                   Status = o.Status
               }); 
    foreach (var customer in OrdersAndCustomers)
        Console.WriteLine(customer.ToString());*/

    //Task8... Join Order Products
    /*Product product1 = new Product { Name = "Laptop", Price = 110, StockQuantity = 12 };
    Product product2 = new Product { Name = "Iphone", Price = 80, StockQuantity = 23 };

    Order order1 = new Order { Date = new DateTime(2023, 8, 5, 8, 30, 52),CustomerId = 1, TotalAmount = 32, Status = "paid" };
    Order order2 = new Order { Date = new DateTime(2008, 8, 8, 8, 30, 52),CustomerId = 2, TotalAmount = 123, Status = "paid" };

    ProductOrder p = new ProductOrder { product = product1, order = order1 };
    ProductOrder p1 = new ProductOrder { product = product1, order = order2 };
    ProductOrder p2 = new ProductOrder { product = product2, order = order1 };
    ProductOrder p4 = new ProductOrder { product = product2, order = order2 };
    ts.Products.Add(product1);
    ts.Products.Add(product2);
    ts.Orders.Add(order1);
    ts.Orders.Add(order2);
    ts.productOrders.Add(p);
    ts.productOrders.Add(p1);
    ts.productOrders.Add(p2);
    ts.productOrders.Add(p4);

    ts.SaveChanges();*/

    /* var prodOrd = ts.Products.Include(p => p.productOrders).ThenInclude(c => c.order).ToList();
     foreach (var prod in prodOrd)
     {
         Console.WriteLine(prod.Name);
         foreach (var product in prod.productOrders)
             Console.WriteLine(product.order.Date);
     }*/

    //Task9... Join Customer and Order Details
    /* var orderCustomers = ts.Orders.Join(ts.Customers,
         c => c.CustomerId,
         o => o.Id,
         (c, o) => new
         {
             Name = o.Name,
             Addres = o.Address,
             Number = o.ContactNumber,
             Date = c.Date,
             Amount = c.TotalAmount,
             Status = o.Status

         });*/
    //----------------------?

    //Task10... Group Orders by Status
    /*var groups = ts.Orders.GroupBy(c => c.Status).Select(g => new { g.Key, counter = g.Count() }).ToList();
    foreach (var group in groups)
        Console.WriteLine(group.Key + " : " + group.counter);*/

    //Task11...Group Products by Category
    /*var groups = ts.Products.GroupBy(x => x.Category)
            .Select(g => new { g.Key, average = g.Average(p => p.Price)}).ToList();
    foreach (var group in groups)
        Console.WriteLine(group.Key + " : " + group.average + "$");*/

    //Task12...Group Customers by Country
    /*var groups = ts.Customers.GroupBy(x => x.Address).Select(x => new { x.Key, counter = x.Count() }).ToList();
    foreach (var group in groups)
        Console.WriteLine($"From {group.Key} there are {group.counter} customers");*/

    //Task13...
    /*NewCustomer cust1 = new NewCustomer("Vardan", "Hrazdan", "+37494831910", "Vardan.sargsyan@mail.com", "Active");
    NewCustomer cust2 = new NewCustomer("Vahe", "Yerevan", "+37494865610", "dasdsyan@mail.com", "Inactive");
    NewCustomer cust3 = new NewCustomer("Karen", "Yerevan", "+37498561910", "Vsdsdn@mail.com", "Active");
    NewCustomer cust4 = new NewCustomer("Ani", "Yerevan", "+37494845565", "Anikkaa@gmail.com", "Inactive");
    ts.newCustomer.Add(cust1);
    ts.newCustomer.Add(cust2);
    ts.newCustomer.Add(cust3);
    ts.newCustomer.Add(cust4);

    ts.SaveChanges();*/
    /*
        var union = ts.Customers.Select(c => new { Name = c.Name, Email = c.Email }).
                Union(ts.newCustomer.Select(c => new { Name = c.Name, Email = c.Email })).ToList();
        foreach (var customer in union)
            Console.WriteLine(customer.Name + " " + customer.Email);*/

    //Task 14: Find Common Products
    /*FeaturedProducts product1 = new FeaturedProducts { Name = "Acer Aspire", Category = "Laptop" };
    FeaturedProducts product2 = new FeaturedProducts { Name = "Iphone 13", Category = "Telephone" };
    FeaturedProducts product3 = new FeaturedProducts { Name = "Hisense", Category = "TV" };
    FeaturedProducts product4 = new FeaturedProducts { Name = "IWatch", Category = "Watch" };
    ts.features.Add(product1);
    ts.features.Add(product2);
    ts.features.Add(product3);
    ts.features.Add(product4);
    BestSellerProducts best1 = new BestSellerProducts { Name = "Iphone 13", Category = "Telephone" };
    BestSellerProducts best2 = new BestSellerProducts{ Name = "Hisense", Category = "TV" };
    BestSellerProducts best3 = new BestSellerProducts { Name = "IWatch", Category = "Watch" };
    ts.bestSellerProducts.Add(best1);
    ts.bestSellerProducts.Add(best2);
    ts.bestSellerProducts.Add(best3);
    ts.SaveChanges();   */

    /*var intersect = ts.Products.Select(p => new { Name = p.Name, Category = p.Category})
        .Intersect(ts.features.Select(c => new { Name = c.Name, Category = c.Category}))
        .Intersect(ts.bestSellerProducts.Select(d => new { Name = d.Name,Category = d.Category})).ToList();
    foreach(var i in intersect)
        Console.WriteLine(i.Name + " " + i.Category );*/


    //Task 15: Identify Non-Duplicate Orders
    /*CancelledOrders c1 = new CancelledOrders { OrderId = 7 };
    CancelledOrders c2 = new CancelledOrders { OrderId = 9 };
    ts.cancelledOrders.Add(c1);
    ts.cancelledOrders.Add(c2);

    ts.SaveChanges();*/

    /* var cancelled = ts.Orders.Except(ts.cancelledOrders.Select(p => p.Order)).ToList();
     foreach (var cancelledOrder in cancelled)
         Console.WriteLine(cancelledOrder.Id + " " + cancelledOrder.Date);*/


    //Task 16: Calculate Total Order Amount
    /*var totalAmount = ts.Orders.Sum(p => p.TotalAmount);
    Console.WriteLine(totalAmount);*/

    //Task 17: Find Maximum Product Price
    /*var maxPrice = ts.Products.Max(p => p.Price);
    Console.WriteLine(maxPrice);*/

    //Task 18: Determine Average Call Duration
    /*CallDetails call1 = new CallDetails("+37494831910", "+37477896896", new DateTime(2023, 8, 12, 15, 30, 45), new DateTime(2023, 8, 12, 15, 48, 45));
    CallDetails call2 = new CallDetails("+37494831910", "+37477896896", new DateTime(2023, 8, 12, 15, 50, 23), new DateTime(2023, 8, 12, 15, 51, 14));
    CallDetails call3 = new CallDetails("+37494831910", "+37477896896", new DateTime(2023, 8, 12, 15, 53, 16), new DateTime(2023, 8, 12, 15, 53, 54));
    CallDetails call4 = new CallDetails("+37494831910", "+37477896896", new DateTime(2023, 8, 12, 15, 57, 40), new DateTime(2023, 8, 12, 15, 58, 50));
    ts.callDetails.Add(call1);
    ts.callDetails.Add(call2);
    ts.callDetails.Add(call3);
    ts.callDetails.Add(call4);
    ts.SaveChanges();*/
    //var callDetails = ts.callDetails.ToList();

    //var average = callDetails.Average(p => (p.EndDate - p.StartDate).TotalSeconds);
    //Console.WriteLine(average);

    //Task 19:Retrieve Customers with Tracking
    /* var customers = ts.Customers.ToList();*/


    //Task 20: Retrieve Products Without Tracking

    /* var products = ts.Products.AsNoTracking().ToList();*/

    //Task 21: Apply Soft Delete Filter

    /*var cust = ts.Customers.FirstOrDefault();
    cust.IsDeleted = true;
    ts.SaveChanges();
    var customers = ts.Customers.ToList();
    foreach(var customer in customers)
        Console.WriteLine(customer.Name);*/

    //Task 22: Update Product Prices
    //ts.Products.ExecuteUpdate(p => p.SetProperty(c => c.Price, c =>  c.Price*1.1));

    //Task 23: Delete Old Orders
    //ts.Orders.Where(c => c.Date < DateTime.Now.AddYears(-1)).ExecuteDelete();
}
//Task11
//Func<TasksContext, int, Customer?> customerById =
//            EF.CompileQuery((TasksContext ts, int id) =>
//                    ts.Customers.FirstOrDefault(c => c.Id == id));
using (TasksContext ts = new TasksContext())
{
    //FromSqlRaw / ExecuteSqlRaw:
    //Task 1: Retrieve Products Using Raw SQL
    /*SqlParameter param = new SqlParameter("@Price", "200");
    var products = ts.Products.FromSqlRaw("SELECT * FROM Products WHERE Price > {0}", param);
    foreach (var product in products)
        Console.WriteLine(product.Name);*/

    //Task 2: Update Product Prices Using Raw SQL
    /*string category = "Laptop";
    int newPrice = 350;
    int s = ts.Database.ExecuteSqlRaw("UPDATE Products SET Price={0} WHERE Category={1}", newPrice , category);
    Console.WriteLine($"{s} rows updated!");*/

    //FromSqlInterpolated / ExecuteSqlInterpolated:
    //Task 3: Retrieve Customers Using Interpolated SQL
    /*var number = "%561%";
    var customers = ts.Customers.FromSqlInterpolated($"SELECT * FROM Customers WHERE ContactNumber LIKE {number}").ToList();
    foreach ( var customer in customers )
        Console.WriteLine(customer.Name + " " + customer.ContactNumber);*/

    //????   //Task 4: Delete Inactive Customers Using Interpolated SQL
    /*DateTime sixMonthAgo = DateTime.Now.AddMonths(-6);
    int sumOfDeleted = ts.Database.ExecuteSqlInterpolated($@"DELETE FROM Customers 
                        WHERE Id NOT IN
                        (SELECT CustomerId 
                         FROM Orders
                         WHERE Date >= {sixMonthAgo})");*/
    /*int sumOfDeleted = ts.Database.ExecuteSqlInterpolated($@"DELETE FROM Customers  WHERE Id IN
         (SELECT Id 
          FROM Customers 
          JOIN Orders ON CustomerId = Id 
          WHERE Date <= {lastSixMonth}");*/

    //Console.WriteLine($"{sumOfDeleted} Customers are Deleted!");

    //Stored Functions:
    //Task 5: Use Scalar-valued Stored Function

    //lucum.....

    /* var cust = ts.Set<CustomerAge>().FromSqlRaw("SELECT dbo.GetAge('2001-14-10') as age").FirstOrDefault();
     Console.WriteLine(cust.Age);
         */

    /*var customers = ts.Customers;
    foreach (var cust in customers)
    {
        ts.GetAge(cust.dateOfBirth);
    }*/



    //Task 6: Use Table-valued Stored Function

    //SqlParameter param = new SqlParameter("@param", 50);
    //var orders = ts.Orders.FromSqlRaw("SELECT * FROM SpecificOrders (@param)", param).ToList();
    //foreach (var order in orders)
    //    Console.WriteLine(order.Id + " " + order.TotalAmount);

    /*
        var ord = ts.SpecificOrders(50);
        foreach (var o in ord)
            Console.WriteLine(o.Id + " " + o.TotalAmount);*/

    /*var orders = ts.Orders.FromSqlRaw("SELECT * FROM dbo.SpecificOrders(50)").ToList();
    foreach (var order in orders)
        Console.WriteLine(order.Id + " " + order.TotalAmount);*/

    //Stored Procedures:
    //Task 7: Call a Simple Stored Procedure
    //SqlParameter param = new()
    //{
    //    ParameterName = "@countOrders",
    //    SqlDbType = System.Data.SqlDbType.Int,
    //    Direction = System.Data.ParameterDirection.Output,
    //};
    //ts.Database.ExecuteSqlRaw("CountOrders {0}, @countOrders OUT",1, param);
    //Console.WriteLine(param.Value);

    //Task 8: Execute Complex Stored Procedure

    //SqlParameter param = new("@customerId", 1);
    //var a = ts.Database.ExecuteSqlRaw("AverageCallDuration 1");
    //Console.WriteLine(a);

    //Task9
    /*try
    {
        Customer? customer = ts.Customers.FirstOrDefault();
        if (customer != null)
        {
            customer.Name = "Bob";
            ts.SaveChanges();
            Console.WriteLine(customer.Name);
            
        }
        throw new DbUpdateConcurrencyException();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        string filePath = "C:\\Users\\User\\OneDrive\\Рабочий стол\\EFCore\\ConsoleApp1\\myLogger.txt";
        using (StreamWriter writer = new StreamWriter(filePath,true))
        {
            writer.WriteLine(ex.Message); 
        }
    }*/

    //Task10
    /*ts.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
    Customer c = new Customer("Hayk", "Yerevan", "+37498659865", "sdftgyhuji.@mail.ru", "paid");

    ts.Customers.Add(c);
    ts.SaveChanges();

    var customers = ts.Customers.ToList();
    foreach (var customer in customers)
        Console.WriteLine(customer.Name + " " + customer.Address);*/

    //Task11: Create and Use Compiled Query...in the top 
    //var customer = customerById(ts, 1);
    //if(customer != null)
    //    Console.WriteLine(customer.Name);
    //else
    //    Console.WriteLine("THE CUSTOMER HAS NOT FOUND!");
    //Task12
    /*ts.Database.ExecuteSqlRaw(@"CREATE VIEW View_CustomerOrders AS 
                                            SELECT Orders.Date AS Date,Orders.TotalAmount AS TotalAmount,Orders.Status AS Status,Customers.Name AS CustomerName
                                            FROM Orders
                                            INNER JOIN Customers on Customers.Id = Orders.customerId");

*/
    //var custom = ts.Customs.ToList();
    //foreach (var cust in custom)
    //{
    //    Console.WriteLine($"Name : {cust.CustomerName}");
    //    Console.WriteLine($"Date : {cust.Date}");
    //    Console.WriteLine($"Amount : {cust.TotalAmount}");
    //    Console.WriteLine($"Status : {cust.Status}");


    //}
    //Task13

    /*Customer firstCustomer = ts.Customers.FirstOrDefault();
    if(firstCustomer != null )
    {
        firstCustomer.Name = "Garik";
        ts.SaveChanges();

        firstCustomer.Name = "Lilith";
        ts.SaveChanges();
    }
    Customer l = ts.Customers.FirstOrDefault(p => p.Name=="Lilith");
    if (l != null)
    {
        var custEntry = ts.Entry(l);
        var createdAt = custEntry.Property<DateTime>("PeriodStart").CurrentValue;
        var deletedAt = custEntry.Property<DateTime>("PeriodEnd").CurrentValue;
        Console.WriteLine($"пользователь {l.Name}");
        Console.WriteLine($"Дата создания: {createdAt}");
        Console.WriteLine($"Дата удаления {deletedAt}");
    }*/
}
