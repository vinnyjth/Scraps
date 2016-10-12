namespace Scraps.Controllers {


    export class ProjectionController {

        public productResource;
        public projections;
        public onhandCalculations;

        public getProjections() {
            this.productResource.getProjections().$promise.then((data) => {
                this.projections = data;
            })       
        }
        public calculateOnHand() {
            this.productResource.calculateOnHand().$promise.then((data) => {
                this.onhandCalculations = data;
            });
        }

        constructor($resource: ng.resource.IResourceService) {
            this.productResource = $resource('api/products/calculateProfit', null, {
                getProjections: {
                    method: 'GET',
                    url: '/api/products/calculateProfit',
                    isArray: true
                },
                calculateOnHand: {
                    method: 'GET',
                    url: '/api/products/calculateOnHand',
                    isArray: true
                }
            });
            this.getProjections();
            this.calculateOnHand();
        }
    }
}