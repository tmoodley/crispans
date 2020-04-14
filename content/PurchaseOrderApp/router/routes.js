const CreatePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/create.vue')
const ManagePurchaseOrder = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/manage.vue')
const PurchaseOrders = () => import(/* webpackChunkName: "home" */ 'components/purchaseorders/orders.vue')

export const routes = [
  { name: 'CreatePO', path: '/PurchaseOrders/Create', component: CreatePurchaseOrder, display: 'Create Purchase Order', icon: 'home' },
  { name: 'ManagePO', path: '/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home' },
  { name: 'Orders', path: '/PurchaseOrders/Manage', component: PurchaseOrders, display: 'Purchase Orders', icon: 'home' }
]
