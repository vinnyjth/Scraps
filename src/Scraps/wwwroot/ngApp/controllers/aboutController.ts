namespace Scraps.Controllers {

    export class AboutController {
        public products;

        constructor(productService: Scraps.Services.ProductService) {
            productService.listProducts().then((data) => {
                this.products = data;
            });
        }
    }
}