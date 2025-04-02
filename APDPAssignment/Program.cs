using APDPAssignment.Data;
using APDPAssignment.Repositories;
using APDPAssignment.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddSingleton<IClassroomRepository, ClassroomRepository>();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<IEnrollmentListRepository, EnrollmentListRepository>();
builder.Services.AddSingleton<ILecturerRepository, LecturerRepository>();
builder.Services.AddSingleton<IAdminRepository, AdminRepository>();
builder.Services.AddSingleton<IRolesRepository, RolesRepository>();
builder.Services.AddSingleton<IAcademicRecordsRepository, AcademicRecordsRepository>();
builder.Services.AddSingleton<ISemesterRepository, SemesterRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();

builder.Services.AddSingleton<ICourseService, CourseService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IStudentService, StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
