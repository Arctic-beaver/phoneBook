import { InputContact } from "./inputContact";
import { OrganizationType } from "./organizationType";

export interface InputOrganization extends InputContact {
    website?: string;
    email?: string;
    organizationType: OrganizationType;
}