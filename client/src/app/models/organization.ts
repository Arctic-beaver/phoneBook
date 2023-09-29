import { Contact } from "./contact";
import { OrganizationType } from "./organizationType";

export interface Organization extends Contact {
    website?: string;
    email?: string;
    organizationType: OrganizationType;
}
