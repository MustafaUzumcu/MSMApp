using Microsoft.AspNetCore.Mvc;

namespace MSMApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly ILogger<InvoiceController> _logger;
    private readonly IRepositoryBase<InvoiceDetail> _invoiceRepository;
    private readonly IRepositoryBase<Customer> _customerRepository;

    private readonly IRepositoryBase<CustomerType> _customerTypeRepository;

    public InvoiceController(ILogger<InvoiceController> logger,
    IRepositoryBase<InvoiceDetail> invoiceRepository,
    IRepositoryBase<Customer> customerRepository,
    IRepositoryBase<CustomerType> customerTypeRepository)
    {
        _logger = logger;
        _invoiceRepository = invoiceRepository;
        _customerRepository = customerRepository;
        _customerTypeRepository = customerTypeRepository;
    }

    [HttpPost]
    public IActionResult GetInvoiceTotal(string userName, int invoiceId)
    {
        var customer = _customerRepository
                        .GetByCondition(q => q.Username == userName).FirstOrDefault();
        if (customer == null)
        {
            return NotFound();
        }

        var invoices = _invoiceRepository.GetByCondition(q => q.InvoiceId == invoiceId);
        var invoiceTotal = ApplyDiscount(invoices, customer);

        return Ok(invoiceTotal);
    }

    private float ApplyDiscount(IQueryable<InvoiceDetail> invoices, Customer customer)
    {
        float invoiceTotal = 0;
        float discount = 0;
        var customerType = _customerTypeRepository
                            .GetByCondition(q => q.CustomerTypeId == customer.CustomerTypeId)
                            .FirstOrDefault();
        if (customerType != null)
        {
            discount = customerType.DiscountValue;
        }
        foreach (var iDetail in invoices)
        {
            // MarketId == 33
            if (iDetail.ProductCategory != 33 && discount > 0)
            {
                invoiceTotal += iDetail.ProductPrice - ((iDetail.ProductPrice / 100) * discount);
            }
            else
            {
                invoiceTotal += iDetail.ProductPrice;
            }
        }
        return invoiceTotal;
    }
}