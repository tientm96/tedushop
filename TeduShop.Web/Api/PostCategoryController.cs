using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

using TeduShop.Web.Models;
using TeduShop.Web.Infrastructure.Extensions;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService) //hàm tạo kế thừa hàm tạo của lớp cha.
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                //Ở đây là get: là lấy từ db lên, nên listCategory phải get dataModel từ service lên. 

                //Sau đó nó phải truyền qua viewModel để viewModel hiển thị lên view, bằng cách dùng Mapper.
                //  Bên dưới khi dùng Mapper ta thấy, đối tượng truyền vào là listCategory lấy từ dataModel, 
                //      đối tượng nhận trả về là PostCategoryViewModel chính là một viewModel.

                //Sau khi dữ liệu cho viewModel, ta gửi lên cho FE thông qua HttpResponseMessage, 
                //  ta gửi lên 1 list viewModel chính là listPostCategoryVm.
                //  cuối cùng là return về respone đó để nó gửi lên FE khi gọi đúng api này.


                var listCategory = _postCategoryService.GetAll();
                
                //đối tượng trả về là PostCategoryViewModel, đối tượng truyền vào là listCategory
                var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                //respone trả về là trả về 1 list listPostCategoryVm, phải trả về giá trị list
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);

                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid) // kiểm tra table có valid theo các tiêu chí required bên DataModel chưa.
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //Ở đây là POST: nên ta truyền dl từ viewModel xuống dataModel.
                    //View nhận dl sẽ truyền vào viewModel, viewModel chính là param postCategoryVm được truyền cho hàm Post này.

                    //Đối tượng newPostCategory của class PostCategory là đối tượng của dataModel, 
                    //  nó nhận giá trị mapper từ viewModel thông qua Extensions method UpdatePostCategory.
                    //  Không thao tác trực tiếp trên dataModel, tránh lỗi xẩy ra.

                    //Lúc này nó dataModel đã có giá trị truyền từ viewModel. Nó gọi tới service add và truyền giá trị xuống để
                    //  service add vào db.

                    //response sẽ nhận giá trị add xuống để gửi lên FE giá trị vừa add, và mã code create thành công là 201.

                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVm); // gọi method extensions, update xuống dataModel tại dòng này

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);

                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //lấy dataModel postCategoryDb ra theo id.
                    //Phải lấy nó ra r mới map, như v mới đúng chính xác từng thuộc tính của dataModel,
                    //  lúc đó map vào, nó có thuộc tính nào sẽ cập nhật cái đó, ko bị dư thừa.

                    //nếu như gán map cho 1 cái rỗng, thì nó sẽ chứa full thuộc tính của viewModel, 
                    //  lúc đấy đưa xuống service update theo dataModel sẽ bị sai.

                    var postCategoryDb = _postCategoryService.GetById(postCategoryVm.ID);

                    //dataModel postCategoryDb này sẽ gọi tới Extensions method UpdatePostCategory, với đối tượng truyền vào là viewModel,
                    // để mapper dữ liệu vừa cập nhập vào dataModel.
                    postCategoryDb.UpdatePostCategory(postCategoryVm);

                    //Lúc này dataModel đã có dl, nó sẽ gọi đến hàm service update và truyền vào dataModel đó,
                    //  để service update xuống db. 
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save(); //gọi đến entity commit()

                    //response sẽ nhận giá trị update và gửi lên FE, kèm theo code update thành công 200.
                    //  nhưng ở đây ta chỉ truyền lên mỗi code 200, chưa có dữ liệu truyền lên sau update (xem lại chỗ này.)
                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                //trả về response để gửi lên FE
                return response;
            });
        }

        [HttpDelete]

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    //gọi tới service delelte theo id truyền vào.
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                //trả về response để gửi lên FE, chỉ trả về trạng thái code 200.
                return response;
            });
        }

        //NẾU CÓ:
        //      POST api/<controller>
        //      FromBody: tiền tố ép buộc phải lấy tham số từ prj, 
        //                  ko đc nhận tham số từ url. (TH bảo mật)
        //public void Post([FromBody]string value){}
    }
}