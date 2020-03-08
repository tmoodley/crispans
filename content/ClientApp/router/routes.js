import Partner from 'components/partner'
import Job from 'components/job'
import Jobs from 'components/jobs'

export const routes = [
  { name: 'dashboard', path: '/portal/dashboard', component: Partner, display: 'My Profile', icon: 'home' },
  { name: 'createrfq', path: '/portal/rfq/create', component: Job, display: 'Create RFQ', icon: 'eye' },
  { name: 'searchrfqs', path: '/portal/rfq/search', component: Job, display: 'Search RFQs', icon: 'eye' },
  { name: 'myrfqs', path: '/portal/rfq/', component: Jobs, display: 'My RFQs', icon: 'tasks' },
  { name: 'quotes', path: '/portal/rfq/', component: Jobs, display: 'Sent Quotes', icon: 'tasks' },
  { name: 'searchcompanies', path: '/portal/companies/search/', component: Jobs, display: 'Search Companies', icon: 'tasks' },
]
