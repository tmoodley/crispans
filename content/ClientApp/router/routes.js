const Partner = () => import(/* webpackChunkName: "home" */ 'components/partner.vue')
const Job = () => import(/* webpackChunkName: "about" */ 'components/jobs/job.vue')
const Jobs = () => import(/* webpackChunkName: "contact" */ 'components/jobs/jobs.vue')

export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Partner, display: 'My Profile', icon: 'home' },
  { name: 'createrfq', path: '/portal/rfq/create', component: Job, display: 'Create RFQ', icon: 'eye' },
  { name: 'searchrfqs', path: '/portal/rfq/search', component: Job, display: 'Search RFQs', icon: 'eye' },
  { name: 'myrfqs', path: '/portal/rfq/', component: Jobs, display: 'My RFQs', icon: 'tasks' },
  { name: 'quotes', path: '/portal/rfq/', component: Jobs, display: 'Sent Quotes', icon: 'tasks' },
  { name: 'searchcompanies', path: '/portal/companies/search/', component: Jobs, display: 'Search Companies', icon: 'tasks' }
]
