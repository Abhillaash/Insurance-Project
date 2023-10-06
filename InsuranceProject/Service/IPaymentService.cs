using InsuranceProject.Model.Holdings;

namespace InsuranceProject.Service
{
    public interface IPaymentService
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        Payment AddPayment(Payment payment);
        //Payment UpdatePayment(Payment payment);
        //bool DeletePayment(int id);
    }
}
