namespace Scraps.Controllers {

    export class HomeController {
        public products;

        constructor(productService: Scraps.Services.ProductService) {
            productService.listProducts().then((data) => {
                this.products = data;
            });
        }
    }
}