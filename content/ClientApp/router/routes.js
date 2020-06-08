/// <reference path="index.js" />
const Dashboard = () => import(/* webpackChunkName: "Partner" */ 'components/dashboard.vue')
const Partner = () => import(/* webpackChunkName: "Partner" */ 'components/partner.vue')
const Job = () => import(/* webpackChunkName: "Job" */ 'components/tenders/job.vue')
const Jobs = () => import(/* webpackChunkName: "Jobs" */ 'components/tenders/jobs.vue')
const TenderEdit = () => import(/* webpackChunkName: "Job" */ 'components/tenders/edit.vue')
const CreatePurchaseOrder = () => import(/* webpackChunkName: "CreatePurchaseOrder" */ 'components/purchaseorders/create.vue')
const ManagePurchaseOrder = () => import(/* webpackChunkName: "ManagePurchaseOrder" */ 'components/purchaseorders/manage.vue')
const PurchaseOrders = () => import(/* webpackChunkName: "PurchaseOrders" */ 'components/purchaseorders/orders.vue')
const Product = () => import(/* webpackChunkName: "ManageProducts" */ 'components/Products/manage.vue')
const Products = () => import(/* webpackChunkName: "SearchProduct" */ 'components/Products/list.vue')
const Bid = () => import(/* webpackChunkName: "ManageBids" */'components/bids/details.vue')
const Question = () => import('components/question/details.vue')
const MyBids = () => import('components/mybids/manage.vue')
const Projects = () => import(/* webpackChunkName: "Projects" */ 'components/Project/Projects.vue')
const ProjectCreate  = () => import(/* webpackChunkName: "CreateProject" */ 'components/Project/Project.vue')
const LoginPage = () => import('components/login/LoginPage.vue')

const ifNotAuthenticated = (to, from, next) => { 
  if (to.name == 'login') {
    localStorage.removeItem('user');
    next()
    return
  }
  else {
    const loggedIn = localStorage.getItem('user');
    if (loggedIn) {
      next('/portal/dashboard')
      return
    }
  }

  next()
  return
}

const ifAuthenticated = (to, from, next) => {
  const loggedIn = localStorage.getItem('user');
  if (loggedIn) {
    next()
    return
  }
  next('/login')
}

export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Dashboard, display: 'Dashboard', icon: 'home', showOnMenu: true, beforeEnter: ifAuthenticated },
  { name: 'Profile', path: '/portal/Profile', component: Partner, display: 'My Profile', icon: 'home', showOnMenu: true, beforeEnter: ifAuthenticated },
  { name: 'createtender', path: '/portal/tender/create', component: Job, display: 'Create Tender', icon: 'info', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'searchtender', path: '/portal/tender/search', component: Jobs, display: 'Search Tenders', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'managetender', path: '/portal/tender/manage/:id', component: TenderEdit, display: 'Edit Tenders', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'CreatePO', path: '/portal/PurchaseOrders/Create', component: CreatePurchaseOrder, display: 'Create Purchase Order', icon: 'home', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ManagePO', path: '/portal/PurchaseOrders/Manage/:id', component: ManagePurchaseOrder, display: 'Manage Purchase Order', icon: 'home', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'Orders', path: '/portal/PurchaseOrders/Manage', component: PurchaseOrders, display: 'Purchase Orders', icon: 'home', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'CreateProduct', path: '/portal/Products/Create', component: Product, display: 'Create Product', icon: 'info', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'SearchProduct', path: '/portal/Products/Manage', component: Products, display: 'Search Products', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ManageProducts', path: '/portal/Products/Manage/:id', component: Product, display: 'Manage Products', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ManageBid', path: '/portal/Bids/Manage/:docid/:bidderid/:src', component: Bid, display: 'Manage Bid', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ManageQuestion', path: '/portal/Question/Manage/:id', component: Question, display: 'Manage Question', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ManageMyBids', path: '/portal/mybids/', component: MyBids, display: 'My Bids', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'Projects', path: '/portal/Projects/', component: Projects, display: 'Projects', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  { name: 'ProjectCreate', path: '/portal/Projects/Create', component: ProjectCreate , display: 'Create Project', icon: 'list', showOnMenu: false, beforeEnter: ifAuthenticated },
  {
    name: 'login',
    path: '/login',
    component: LoginPage,
    showOnMenu: false,
    beforeEnter: ifNotAuthenticated,
  }
]
