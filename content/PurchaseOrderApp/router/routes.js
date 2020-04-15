const CreatePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/create.vue')
const ManagePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/manage.vue')
const Job = () => import(/* webpackChunkName: "about" */ 'components/jobs/job.vue')
const Jobs = () => import(/* webpackChunkName: "contact" */ 'components/jobs/jobs.vue')
const PurchaseOrders = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/orders.vue')

export const routes = [
  { name: 'CreatePO', path: '/PurchaseOrders/Create', component: CreatePurchaseOrder, display: 'Create Purchase Order', icon: 'home' },
  { name: 'ManagePO', path: '/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home' },
  { name: 'Buyer', path: '/Buyer/Create', component: CreatePurchaseOrder, display: 'Create Buyer Purchase Order', icon: 'home' },
  { name: 'CreateTender', path: '/Tenders/Create', component: Job, display: 'Create Product', icon: 'info' },
  { name: 'ManageTenders', path: '/Tenders/Manage:id', component: Jobs, display: 'Manage Products', icon: 'list' },
  { name: 'SearchTenders', path: '/Tenders/Manage', component: Jobs, display: 'Search Products', icon: 'list' }
  { name: 'ManagePO', path: '/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home' },
  { name: 'Orders', path: '/PurchaseOrders/Manage', component: PurchaseOrders, display: 'Purchase Orders', icon: 'home' }
]
