namespace Scraps.Controllers {

    export class ProductsDeleteController {
        public productToDelete;

        deleteProduct() {
            this.productService.deleteProduct(this.productToDelete.id).then(
                () => this.$state.go('Home')
            );
        }
        constructor(private productService: Scraps.Services.ProductService, private $state: ng.ui.IStateService, $stateParams: ng.ui.IStateParamsService) {
            this.productToDelete = productService.getProduct($stateParams['id'])
        }
    }
}