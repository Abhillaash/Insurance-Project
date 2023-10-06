using InsuranceProject.Model.Holdings;
using InsuranceProject.Repository;

namespace InsuranceProject.Service
{
    public class PaymentService: IPaymentService
    {
        private readonly IEntityRepository<Payment> _repository;

        public PaymentService(IEntityRepository<Payment> entityRepository)
        {
            _repository = entityRepository;
        }

        public List<Payment> GetAllPayments()
        {
            return _repository.GetAll().ToList();
        }

        public Payment GetPaymentById(int id)
        {
            return _repository.GetById(id);
        }

        public Payment AddPayment(Payment payment)
        {
            _repository.Add(payment);
            return payment;
        }

        //public Payment UpdatePayment(Payment payment)
        //{
        //    if (_repository.Update(payment, payment.PaymentId) != null)
        //    {
        //        return _repository.Update(payment, payment.PaymentId);
        //    }
        //    throw new Exception("No such payment found");
        //}

        //public bool DeletePayment(int id)
        //{
        //    var deletePayment = _repository.GetById(id);
        //    if (deletePayment != null)
        //    {
        //        deletePayment.Status = false;
        //        _repository.Delete(deletePayment, deletePayment.PaymentId);
        //        return true;
        //    }
        //    throw new Exception("No such payment");
        //}
    }
}
