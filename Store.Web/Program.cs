using Store.Memory;

namespace Store.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var services = builder.Services;

			services.AddDistributedMemoryCache();
			services.AddControllersWithViews();
			services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(20); //����� ������
				options.Cookie.HttpOnly = true; //��������� � ����� ������ �� ����
				options.Cookie.IsEssential = true; //���������� ��� ���� �� ������� ����������� �������� ������������(��� ����)

			});
            services.AddSingleton<IOrderRepository, OrderRepository>();
			services.AddSingleton<IBookRepository, BookRepository>();
			services.AddSingleton<BookService>();


			var app = builder.Build();


			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSession(); //����������� ������

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}