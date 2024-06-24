
    $(document).ready(function () {
        $("#grid").kendoGrid({
            sortable: true,
            filterable: true,
            pageable: {
                pageSizes: [10, 20, 50],
                buttonCount: 5
            },
            dataSource: {
                transport: {
                    read: "/User/GetUsersData",
                    update: {
                        url: "/User/UpdateUsersData",
                        type: "Post"
                    },
                    create: {
                        url: "/User/UpdateUsersData",
                        type: "Post"
                    },
                    destroy: {
                        url: "/User/DeleteUsersData",
                        type: "Post"
                    }
                },
                schema: {
                    model: {
                        id: "EmpId",
                        fields: {
                            EmpId: { editable: false, nullable: true },
                            DeptName: { validation: { required: true } },
                            MngrName: { validation: { required: true } },
                            EmpName: { validation: { required: true } },
                            Salary: { validation: { required: true }, type: "number" }
                        }
                    }
                },
                pageSize: 10,
            },
            events: {
                edit: "onEdit"
            },
            toolbar: [
                { name: "create", text: "Add New Record" },
                { name: "delete", text: "Delete All", iconClass: "k-icon k-i-trash" }
            ],
            columns: [
                {
                    selectable: true,
                    width: 75,
                    attributes: {
                        "class": "row-checkbox",
                    }
                },

                { field: "EmpId", title: "Employee Id", width: "120px", filterable: false },
                {
                    field: "DeptName",
                    title: "Department",
                    width: "200px",
                    editor: departmentDropDownEditor,
                    filterable: {
                        multi: true,
                        dataSource: {
                            transport: {
                                read: "/User/GetDepartment",
                            },
                            schema: {
                                model: {
                                    id: "DeptId",
                                    fields: {
                                        DeptId: { type: "number" },
                                        DeptName: { type: "string" }
                                    }
                                }
                            }
                        },

                        template: function (dataItem) {
                            return '<input type="checkbox" name="deptFilter" value="' + dataItem.DeptId + '"> ' + dataItem.DeptName;
                        },
                        checkAll: true,
                        messages: {
                            checkAll: "Select All",
                            clear: "Clear",
                            filter: "Apply"
                        },
                        operators: {
                            string: {
                                contains: "Contains"
                            }
                        },
                        ui: "checkbox"
                    }
                },
                {
                    field: "MngrName",
                    title: "Manager",
                    width: "200px",
                    editor: managerDropDownEditor,
                    filterable: {
                        multi: true,
                        dataSource: {
                            transport: {
                                read: '/User/GetManagerList'
                            },
                            schema: {
                                model: {
                                    id: "MngrId",
                                    fields: {
                                        MngrId: { type: "number" },
                                        MngrName: { type: "string" }
                                    }
                                }
                            }
                        },

                        template: function (dataItem) {
                            return '<input type="checkbox" name="mngrFilter" value="' + dataItem.MngrId + '"> ' + dataItem.MngrName;
                        },
                        checkAll: true,
                        message: {
                            checkAll: "Select All",
                            clear: "Clear",
                            filter: "Apply"
                        },
                        operators: {
                            string: {
                                contains: "Contains"
                            }
                        },
                        ui: "checkbox"
                    }
                },
                {
                    field: "EmpName",
                    title: "Employee Name",
                    width: "200px",
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains"
                        },
                        operators: {
                            string: {
                                contains: "Contains",
                                eq: "Equal to",
                                startswith: "Starts with",
                                endswith: "Ends with"
                            }
                        },
                    }
                },
                {
                    field: "Salary",
                    title: "Salary",
                    width: "200px",
                    sortable: true,
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains",
                            template: function (args) {
                                args.element.kendoNumericTextBox({
                                    format: "n0"
                                });
                            }
                        },
                        operators: {
                            number: {
                                eq: "Equal to",
                                lt: "Less than",
                                lte: "Less than or equal to",
                                gt: "Greater than",
                                gte: "Greater than or equal to"
                            }
                        }
                    }
                },
                { command: ["edit", "destroy"], title: "Action", width: "250px" }
            ],

            editable: {
                mode: "popup",
            },

            save: function (e) {
                setTimeout(function () {
                    $("#grid").data("kendoGrid").dataSource.read();
                }, 400);
            },

        });

    $("#grid").on("click", ".k-grid-delete", function () {
        deleteSelectedRows();
        });
       
    });