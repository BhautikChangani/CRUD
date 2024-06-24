
    function departmentDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoMultiColumnComboBox({
                dataTextField: "DeptName",
                dataValueField: "DeptName",
                height: 400,
                width: 400,
                columns: [
                    { field: "DeptId", title: "Department Id", width: 200 },
                    { field: "DeptName", title: "Department Name", width: 200 }
                ],
                footerTemplate: 'Total #: instance.dataSource.total() # items found',
                filter: "contains",
                filterFields: ["DeptName"],
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
                change: function (e) {
                    var widget = e.sender;

                    if (widget.value() && widget.select() === -1) {
                        widget.value("");
                    }
                }
            });
    }

    function managerDropDownEditor(container, options) {
        $('<input required name="' + options.field + '"/>')
            .appendTo(container)
            .kendoMultiColumnComboBox({
                dataTextField: "MngrName",
                dataValueField: "MngrName",
                height: 400,
                width: 400,
                columns: [
                    { field: "MngrId", title: "Manager Id", width: 200 },
                    { field: "MngrName", title: "Manager Name", width: 200 }
                ],
                footerTemplate: 'Total #: instance.dataSource.total() # items found',
                filter: "contains",
                filterFields: ["MngrName"],
                dataSource: {
                    transport: {
                        read: "/User/GetManagerList",
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
                change: function (e) {
                    var widget = e.sender;

                    if (widget.value() && widget.select() === -1) {
                        widget.value("");
                    }
                }
            });
    }

    
