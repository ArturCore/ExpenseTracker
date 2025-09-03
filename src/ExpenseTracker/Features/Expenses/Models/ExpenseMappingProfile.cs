using AutoMapper;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Models
{
    public class ExpenseMappingProfile : Profile
    {
        public ExpenseMappingProfile() 
        { 
            CreateMap<Expense, ExpenseResponse>();
            CreateMap<CreateExpenseRequest, Expense>();
            CreateMap<UpdateExpenseRequest, Expense>();
        }
    }
}
