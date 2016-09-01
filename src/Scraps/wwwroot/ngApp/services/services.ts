namespace Scraps.Services {

    export class ProductService {
        private ProductResource;

        public listProducts() {
            return this.ProductResource.query().$promise;
        }
        public save(product) {
            return this.ProductResource.save(product).$promise;
        }
        public getProduct(id) {
            return this.ProductResource.get({ id: id });
        }
        public deleteProduct(id: number) {
            return this.ProductResource.delete({ id: id }).$promise;
        }
        constructor($resource: ng.resource.IResourceService) {
            this.ProductResource = $resource('/api/products/:id');
        }
    }
    angular.module('Scraps').service('productService', ProductService);
    }
