const Partner = () => import(/* webpackChunkName: "home" */ 'components/partner.vue')
const Job = () => import(/* webpackChunkName: "about" */ 'components/jobs/job.vue')
const Jobs = () => import(/* webpackChunkName: "contact" */ 'components/jobs/jobs.vue')

export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Partner, display: 'My Profile', icon: 'home' },
  { name: 'createtender', path: '/portal/tender/create', component: Job, display: 'Create Tender', icon: 'info' },
  { name: 'searchtender', path: '/portal/tender/search', component: Jobs, display: 'Search Tenders', icon: 'list' }
]
