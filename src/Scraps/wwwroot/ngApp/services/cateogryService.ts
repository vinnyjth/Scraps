namespace Scraps.Services {
    export class CategoryService {
        private CategoryResource;

        public listCategories() {
        
            return this.CategoryResource.query();
        }
        constructor($resource: ng.resource.IResourceService) {
            this.CategoryResource = $resource('/api/categories/:id');
        }
    }
    angular.module('Scraps').service('categoryService', CategoryService);
}