namespace Scraps.Controllers {

    export class ProductsAddController {
        public productToCreate;
        public categories;

        addProduct() {
            this.productService.save(this.productToCreate).then
                (
                () => this.$state.go('home')
                );
        }
        constructor(
            private productService: Scraps.Services.ProductService,
            private $state: ng.ui.IStateService,
            private categoryService: Scraps.Services.CategoryService) {
            this.categories = this.categoryService.listCategories();
        }
    }
}