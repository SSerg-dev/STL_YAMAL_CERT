import {library} from '@fortawesome/fontawesome-svg-core'
// Official documentation available at: https://github.com/FortAwesome/vue-fontawesome
import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome'

import {
    faChevronLeft,
    faChevronRight,
    faEdit,
    faEnvelope,
    faHome,
    faList,
    faPlus,
    faSignOutAlt,
    faSpinner,
    faTrash,
    faUpload,
    faUser
} from '@fortawesome/free-solid-svg-icons'

library.add(
    faEnvelope,
    faUpload,
    faHome,
    faList,
    faSpinner,
    faPlus,
    faEdit,
    faTrash,
    faUser,
    faSignOutAlt,
    faChevronLeft,
    faChevronRight
);

export {
    FontAwesomeIcon
}
