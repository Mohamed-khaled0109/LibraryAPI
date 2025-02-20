using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using System.ComponentModel;

namespace LibraryAPI.Services
{
    public class PaymentRepo:IPaymentRepo
    {
        private readonly Context context;

        public PaymentRepo(Context context)
        {
            this.context = context;
        }

        public List<Payment> GetAll()
        {

            return context.payments.ToList();
        }

        public PaymentDto GetById(int id)
        {
            var payment = context.payments.FirstOrDefault(x => x.Id == id);
            var paymentDto= new PaymentDto();

            paymentDto.State = payment.State;
            paymentDto.UserId = payment.UserId;
            paymentDto.PaymentDate= payment.PaymentDate;
            paymentDto.BookId= payment.BookId;
            paymentDto.amount = payment.amount;

            return paymentDto;
        }

        public int create(PaymentDto paymentDto)
        {
            var payment = new Payment();
            payment.State = paymentDto.State;
            payment.UserId = paymentDto.UserId;
            payment.PaymentDate = paymentDto.PaymentDate;
            payment.BookId = paymentDto.BookId;
            payment.amount = paymentDto.amount;

            context.payments.Add(payment);
            return context.SaveChanges();
        }

        public PaymentDto update(int id, PaymentDto paymentDto)
        {
            var payment = context.payments.FirstOrDefault(c => c.Id == id);

            payment.State = paymentDto.State;
            payment.UserId = paymentDto.UserId;
            payment.PaymentDate = paymentDto.PaymentDate;
            payment.BookId = paymentDto.BookId;
            payment.amount = paymentDto.amount;

            context.SaveChanges();
            return paymentDto;
        }

        public int delete(int id)
        {
            var payment = context.payments.FirstOrDefault(c => c.Id == id);
            context.payments.Remove(payment);
            return context.SaveChanges();
        }
    }
}
