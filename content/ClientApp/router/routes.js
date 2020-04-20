const Partner = () => import(/* webpackChunkName: "home" */ 'components/partner.vue')
const Job = () => import(/* webpackChunkName: "about" */ 'components/jobs/job.vue')
const Jobs = () => import(/* webpackChunkName: "contact" */ 'components/jobs/jobs.vue')
const CreatePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/create.vue')
const ManagePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/manage.vue') 
const PurchaseOrders = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/orders.vue')
const Tender = () => import(/* webpackChunkName: "about" */ 'components/tenders/job.vue')
const Tenders = () => import(/* webpackChunkName: "contact" */ 'components/tenders/jobs.vue')
export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Partner, display: 'My Profile', icon: 'home', showOnMenu: true },
  { name: 'createtender', path: '/portal/tender/create', component: Job, display: 'Create Tender', icon: 'info', showOnMenu: true },
  { name: 'searchtender', path: '/portal/tender/search', component: Jobs, display: 'Search Tenders', icon: 'list', showOnMenu: true },
  { name: 'CreatePO', path: '/PurchaseOrders/Create', component: CreatePurchaseOrder, display: 'Create Purchase Order', icon: 'home', showOnMenu: true },
  { name: 'ManagePO', path: '/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home', showOnMenu: false }, 
  { name: 'Orders', path: '/PurchaseOrders/Manage', component: PurchaseOrders, display: 'Purchase Orders', icon: 'home', showOnMenu: true },
  { name: 'CreateTender', path: '/Tenders/Create', component: Tender, display: 'Create Product', icon: 'info', showOnMenu: true },
  { name: 'SearchTenders', path: '/Tenders/Manage', component: Tenders, display: 'Search Products', icon: 'list', showOnMenu: true },
  { name: 'ManageTenders', path: '/Tenders/Manage/:id', component: Tender, display: 'Manage Products', icon: 'list', showOnMenu: false }
] 
