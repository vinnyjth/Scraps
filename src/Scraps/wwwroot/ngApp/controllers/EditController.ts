namespace Scraps.Controllers {

    export class ProductsEditController {

        public productToEdit;

        editProduct() {
            this.productService.save(this.productToEdit).then(
                () => this.$state.go('home')
            );
        }
        constructor(private productService: Scraps.Services.ProductService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.productToEdit = productService.getProduct($stateParams['id'])
        }
    }
}