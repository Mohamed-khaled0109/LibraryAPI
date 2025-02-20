using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IPaymentRepo
    {
        public List<Payment> GetAll();
        public PaymentDto GetById(int id);
        public int create(PaymentDto paymentDto);
        public PaymentDto update(int id, PaymentDto paymentDto);
        public int delete(int id);

    }
}
