const Dashboard = () => import(/* webpackChunkName: "Partner" */ 'components/dashboard.vue')
const Partner = () => import(/* webpackChunkName: "Partner" */ 'components/partner.vue')
const Job = () => import(/* webpackChunkName: "Job" */ 'components/tenders/job.vue')
const Jobs = () => import(/* webpackChunkName: "Jobs" */ 'components/tenders/jobs.vue')
const CreatePurchaseOrder = () => import(/* webpackChunkName: "CreatePurchaseOrder" */ 'components/purchaseorders/create.vue')
const ManagePurchaseOrder = () => import(/* webpackChunkName: "ManagePurchaseOrder" */ 'components/purchaseorders/manage.vue')
const PurchaseOrders = () => import(/* webpackChunkName: "PurchaseOrders" */ 'components/purchaseorders/orders.vue')
const Product = () => import(/* webpackChunkName: "ManageProducts" */ 'components/Products/manage.vue')
const Products = () => import(/* webpackChunkName: "SearchProduct" */ 'components/Products/list.vue')
export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Dashboard, display: 'Dashboard', icon: 'home', showOnMenu: true },
  { name: 'Profile', path: '/portal/Profile', component: Partner, display: 'My Profile', icon: 'home', showOnMenu: true },
  { name: 'createtender', path: '/portal/tender/create', component: Job, display: 'Create Tender', icon: 'info', showOnMenu: true },
  { name: 'searchtender', path: '/portal/tender/search', component: Jobs, display: 'Search Tenders', icon: 'list', showOnMenu: true },
  { name: 'managetenders', path: '/portal/tender/manage', component: Jobs, display: 'Manage Tenders', icon: 'list', showOnMenu: true },
  { name: 'CreatePO', path: '/portal/PurchaseOrders/Create', component: CreatePurchaseOrder, display: 'Create Purchase Order', icon: 'home', showOnMenu: true },
  { name: 'ManagePO', path: '/portal/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home', showOnMenu: false },
  { name: 'Orders', path: '/portal/PurchaseOrders/Manage', component: PurchaseOrders, display: 'Purchase Orders', icon: 'home', showOnMenu: true },
  { name: 'CreateProduct', path: '/portal/Products/Create', component: Product, display: 'Create Product', icon: 'info', showOnMenu: true },
  { name: 'SearchProduct', path: '/portal/Products/Manage', component: Products, display: 'Search Products', icon: 'list', showOnMenu: true },
  { name: 'ManageProducts', path: '/portal/Products/Manage/:id', component: Product, display: 'Manage Products', icon: 'list', showOnMenu: false }
]
