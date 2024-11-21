using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]/[action]")]

public class FormController:ControllerBase{
 private readonly IMailHandler _mailHandler;

 public FormController(IMailHandler mailHandler)
 {
     _mailHandler = mailHandler;
 }

 
    [HttpPost]
    public async Task<IActionResult> Create(Form form){
        await _mailHandler.SendEmailAsync(new MailRequest()
        {
            Subject = "یک نفر فرم درخواست مشاوره را پر کرده است",
            ToEmail = "sajadrahimi6633@gmail.com",
            Body = @$"<style>
  table {{
    border-collapse: collapse;
    width: 100%;
  }}
  th, td {{
    border: 1px solid #ddd;
    padding: 8px;
    text-align: right;
  }}
  th {{
    background-color: #f0f0f0;
  }}
  h2{{
      text-align:right;
  }}
</style>

<h2>مشخصات وارد شده</h2>

<table>
  <tr>
    <td>{form.firstName}</td>
    <th>نام</th>
  </tr>
  <tr>
    <td>{ form.lastName }</td>
    <th>نام خانوادگی</th>
  </tr>
  <tr>
    <td>{ form.number }</td>
    <th>شماره تلفنr</th>
  </tr>
  <tr>
    <td>{ form.website }</td>
    <th>وب سایت</th>
  </tr>
  <tr>
    <td>{ form.companyName }</td>
    <th>نام شرکت</th>
  </tr>
  <tr>
    <td>{ form.position }</td>
    <th>سمت شما در مجموعه</th>
  </tr>
  <tr>
    <td>{ form.launchTime }</td>
    <th>چه مدت از راه اندازی سایت شما میگذرد؟</th>
  </tr>
  <tr>
    <td>{ form.designerName }</td>
    <th>سایت شما توسط چه کسی طراحی شده است؟</th>
  </tr>  
  <tr>
    <td>{ form.websiteChanges }</td>
    <th>امکان انجام تغییرات در سایت توسط شما یا طراح وجود دارد؟</th>
  </tr>
 
  <tr>
    <td>{ form.websiteType }</td>
    <th>سایت شما با کدام سیستم مدیریت محتوایی طراحی شده است؟</th>
  </tr>
  <tr>
    <td>{ form.hostAccess }</td>
    <th>امکان دسترسی به پنل هاست خود و مدیریت آن دارید؟</th>
  </tr>
  <tr>
    <td>{ form.contentProduction }</td>
    <th>وظیفه تولید محتوا در بخش مقالات سایت به عهده کیست ؟</th>
  </tr>
  <tr>
    <td>{ form.contentAmount }</td>
    <th>به طور متوسط چه تعداد محتوا در ماه منتشر میکنید؟</th>
  </tr>
  <tr>
    <td>{ form.seoActivity }</td>
    <th>برای سئو سایت خود با شخص یا شرکتی همکاری داشته اید؟</th>
  </tr>
  <tr>
    <td>{ form.googleSearchConsole }</td>
    <th>به ابزار google search console سایت دسترسی دارید؟</th>
  </tr>
  <tr>
    <td>{ form.googleAnalytics }</td>
    <th>به ابزار google analyticsسایت دسترسی دارید؟</th>
  </tr>
  <tr>
    <td>{ form.googleAd }</td>
    <th>آیا از گوگل ادوردز استفاده کرده اید ؟</th>
  </tr>
  <tr>
    <td>{ form.googleSuspense }</td>
    <th>تجربه جریمه سایت توسط گوگل یا افت شدید بازدید و جایگاه را داشته اید ؟</th>
  </tr>
  <tr>
    <td>{ form.companyHelp }</td>
    <th>فکر میکنید رایانیک در چه زمینه هایی می تواند به کسب و کار شما کمک کند ؟</th>
  </tr>  
  <tr>
    <td>{ form.seoBudget }</td>
    <th>بودجه ای که به صورت ماهیانه به سئو اختصاص داده اید چقدر است؟</th>
  </tr>  
  <tr>
    <td>{ form.description }</td>
    <th>Description</th>
  </tr>
</table>"
        });
        return Ok(form);
    }

    [HttpPost]
    public async Task<IActionResult> Contact(Contact contact)
    {
           await _mailHandler.SendEmailAsync(new MailRequest()
        {
            Subject = "یک نفر فرم درخواست مشاوره را پر کرده است",
            ToEmail = "sajadrahimi6633@gmail.com",
            Body = @$"<style>
  table {{
    border-collapse: collapse;
    width: 100%;
  }}
  th, td {{
    border: 1px solid #ddd;
    padding: 8px;
    text-align: right;
  }}
  th {{
    background-color: #f0f0f0;
  }}
  h2{{
      text-align:right;
  }}
</style>

<h2>مشخصات وارد شده</h2>

<table>
  <tr>
    <td>{contact.FirstName}</td>
    <th>نام</th>
  </tr>
  <tr>
    <td>{ contact.LastName }</td>
    <th>نام خانوادگی</th>
  </tr>
  <tr>
    <td>{ contact.PhoneNumber }</td>
    <th>شماره تلفنr</th>
  </tr>
  <tr>
    <td>{ contact.Email }</td>
    <th>وب سایت</th>
  </tr>
  <tr>
    <td>{ contact.Message }</td>
    <th>نام شرکت</th>
  </tr>
</table>"
        });
        return Ok(contact);
    }
}