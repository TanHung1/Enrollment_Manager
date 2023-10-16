using Microsoft.EntityFrameworkCore;
using Phanmemquanlyghidanh.Models;
using Phanmemquanlyghidanh.Repository;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EnrollmentDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EnrollmentDB"));
});



// Defendence Intraction
builder.Services.AddTransient<IStatusRoomRepository, StatusRoomRepository>();
builder.Services.AddTransient<ISubjectCategoryRepository, SubjectCategoryRepository>();
builder.Services.AddTransient<ITypeMarkRepository, TypeMarkRepository>();
builder.Services.AddTransient<IHolidayScheduleRepository, HolidayScheduleRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ICheckOutRepository, CheckOutRepository>();
builder.Services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
builder.Services.AddTransient<IMarkRepository, MarkRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<IStatusCheckOutRepository, StatusCheckOutRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllers();

app.Run();
